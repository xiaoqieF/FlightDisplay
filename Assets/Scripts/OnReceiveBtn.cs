// 点击开始接收数据按钮

using UnityEngine;
using System;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class OnReceiveBtn : MonoBehaviour
{
    public Text uiContent;
    public TMP_InputField ipInput;
    public TMP_InputField portInput;
    public UdpManager udpManager;

    public Transform redAircraftTrans;
    public Transform blueAircraftTrans;
    public Transform redF16Trans;
    public Transform blueF16Trans;
    public Transform redMissile1Trans;
    public Transform redMissile2Trans;
    public Transform blueMissile1Trans;
    public Transform blueMissile2Trans;

    private Message msg;  // 飞行器和导弹的位置信息(由udpManage更新)
    private string content;
    private const float timeInterval = 1.0f;
    private float passedTime = 0.0f;

    private const int scale = 2000;      // 飞行器坐标缩放比例

    void Start() {
        uiContent = GameObject.Find("Content").GetComponent<Text>();
        ipInput = GameObject.Find("ipInput").GetComponent<TMP_InputField>();
        portInput = GameObject.Find("portInput").GetComponent<TMP_InputField>();

        redAircraftTrans = GameObject.Find("RedAircraft").GetComponent<Transform>();
        redF16Trans = GameObject.Find("F16-1").GetComponent<Transform>();
        blueAircraftTrans = GameObject.Find("BlueAircraft").GetComponent<Transform>();
        blueF16Trans = GameObject.Find("F16-2").GetComponent<Transform>();

        redMissile1Trans = GameObject.Find("RedMissile1").GetComponent<Transform>();
        redMissile2Trans = GameObject.Find("RedMissile2").GetComponent<Transform>();
        blueMissile1Trans = GameObject.Find("BlueMissile1").GetComponent<Transform>();
        blueMissile2Trans = GameObject.Find("BlueMissile2").GetComponent<Transform>();
    }

    void Update() {
        if (msg == null) {
            return;
        }
        passedTime += Time.deltaTime;
        if (passedTime > timeInterval) {
            // 每隔 timeInterval 刷新一次界面
            uiContent.text = content;
            passedTime = 0.0f;
        }
        // 需要从右手系转为 Unity 的左手系
        // unity.x = x; unity.y = z; unity.z = - y
        redAircraftTrans.position = new Vector3(msg.red.x / scale, msg.red.z / scale, - msg.red.y / scale);
        redF16Trans.localEulerAngles = new Vector3(-msg.red.roll, msg.red.yaw, msg.red.pitch);
        blueAircraftTrans.position = new Vector3(msg.blue.x / scale, msg.blue.z / scale, - msg.blue.y / scale);
        blueF16Trans.localEulerAngles = new Vector3(-msg.blue.roll, msg.blue.yaw, msg.blue.pitch);
        if (msg.red.missile1.valid) {
            // Debug.Log("red missile1 launch");
            redMissile1Trans.position = 
                    new Vector3(msg.red.missile1.x / scale, msg.red.missile1.z / scale, -msg.red.missile1.y / scale);
            redMissile1Trans.localEulerAngles = 
                    new Vector3(-msg.red.missile1.roll, msg.red.missile1.yaw, msg.red.missile1.pitch);
        }
        if (msg.red.missile2.valid) {
            // Debug.Log("red missile2 launch");
            redMissile2Trans.position = 
                    new Vector3(msg.red.missile2.x / scale, msg.red.missile2.z / scale, -msg.red.missile2.y / scale);
            redMissile2Trans.localEulerAngles = 
                    new Vector3(-msg.red.missile2.roll, msg.red.missile2.yaw, msg.red.missile2.pitch);
        }
        if (msg.blue.missile1.valid) {
            // Debug.Log("blue missile1 launch");
            blueMissile1Trans.position = 
                    new Vector3(msg.blue.missile1.x / scale, msg.blue.missile1.z / scale, -msg.blue.missile1.y / scale);
            blueMissile1Trans.localEulerAngles = 
                    new Vector3(-msg.blue.missile1.roll, msg.blue.missile1.yaw, msg.blue.missile1.pitch);
        }
        if (msg.blue.missile2.valid) {
            // Debug.Log("blue missile2 launch");
            blueMissile2Trans.position = 
                    new Vector3(msg.blue.missile2.x / scale, msg.blue.missile2.z / scale, -msg.blue.missile2.y / scale);
            blueMissile2Trans.localEulerAngles = 
                    new Vector3(-msg.blue.missile2.roll, msg.blue.missile2.yaw, msg.blue.missile2.pitch);
        }
    }

    // udp数据接收后处理函数(用于回调)
    public void HandleData(byte[] data, int len) {
        content = System.Text.Encoding.UTF8.GetString(data, 0, len);
        // Debug.Log(content);
        msg = JsonUtility.FromJson<Message>(content);
    }

    // 点击开始接收数据按钮
    public void OnReceiveClick() {
        var buttonText = this.GetComponentInChildren<TMP_Text>();
        if (udpManager != null) {
            udpManager.Close();
            udpManager = null;
            buttonText.text = "开始接收数据";
            return;
        }
        if (portInput.text.Length == 0) {
            Debug.Log("empty port");
            return;
        }
        buttonText.text = "停止接收数据";
        string address = ipInput.text;
        int port = Convert.ToInt32(portInput.text);
        udpManager = new UdpManager();
        udpManager.setDataHandler(HandleData);  // 设置回调函数
        udpManager.Init(address, port);
    }
    // 点击发送数据按钮
    public void onSendClick() {
        if (udpManager == null) {
            Debug.Log("no udp open");
            return;
        }
        string content = GameObject.Find("contentInput").GetComponent<TMP_InputField>().text;
        if (content.Length == 0){
            Debug.Log("empty content");
            return;
        }
        udpManager.Send(Encoding.UTF8.GetBytes(content));
    }
}
