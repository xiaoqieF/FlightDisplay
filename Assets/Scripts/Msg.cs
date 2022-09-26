// 通信消息实体类

[System.Serializable]
public class Message {
    public Info red;
    public Info blue;
}

[System.Serializable]
public class Info {
    public float x;   // 右手系坐标
    public float y;
    public float z;
    public float pitch;
    public float roll;
    public float yaw;
    public float v;
    public Missile missile1;
    public Missile missile2;

}

[System.Serializable]
public class Missile {
    public bool valid;
    public float x;
    public float y;
    public float z;
    public float pitch;
    public float roll;
    public float yaw;
}