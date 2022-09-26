using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class UdpManager
{
    // 声明委托变量，类似于函数指针类型
    public delegate void HandleReceive(byte[] data, int len);
    private EndPoint remote;  //保存远端地址
    private EndPoint local;
    private Socket socket;
    private Thread receiveThread;
    byte[] recvData = new byte[1024];
    int len;

    HandleReceive dataHandler;    // 收到消息后的回调

    public void Init(string remoteAddress = "127.0.0.1", int port = 8088) {
        remote = new IPEndPoint(IPAddress.Any, 0);

        local = new IPEndPoint(IPAddress.Any, port);
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        socket.Bind(local);

        receiveThread = new Thread(new ThreadStart(Receive));
        receiveThread.Start();
    }

    public void setDataHandler(HandleReceive handler) {
        dataHandler = handler;
    }

    public void Close() {
        if (receiveThread != null) {
            receiveThread.Interrupt();
            receiveThread.Abort();
        }
        if (socket != null) {
            socket.Close();
        }
    }

    public void Send(byte[] msg) {
        // 当远端地址被保存时才能发送
        if (socket != null && ((IPEndPoint)remote).Port != 0) {
            socket.SendTo(msg, remote);
        } else {
            Debug.Log("No socket or no remote address");
        }

    }

    private void Receive() {
        while (true) {
            try {
                len = socket.ReceiveFrom(recvData, ref remote);
                // 回调处理函数
                if (dataHandler != null) {
                    dataHandler(recvData, len);
                }
            }
            catch (System.Exception e) {
                Debug.Log("Udp receive exception:" + e);
            }
        }
    }

    ~UdpManager() {
        Close();
    }

}
