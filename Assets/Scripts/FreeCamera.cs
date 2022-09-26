// 自由视角相机

using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public Transform cameraTrans;

    public float moveSpeed = 20.0f;
    public float rotateSpeed = 90.0f;
    public float shiftRate = 5.0f;// 按住Shift加速
    public float minDistance = 100.0f;// 相机离不可穿过的表面的最小距离（小于等于0时可穿透任何表面）

    private Vector3 direction = Vector3.zero;
    private Vector3 speedForward;
    private Vector3 speedBack;
    private Vector3 speedLeft;
    private Vector3 speedRight;
    private Vector3 speedUp;
    private Vector3 speedDown;

    // Start is called before the first frame update
    void Start()
    {
        cameraTrans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        RaycastHit hit;
        while (Physics.Raycast(cameraTrans.position, direction, out hit, minDistance))
        {
            // 消去垂直于不可穿透表面的运动速度分量
            float angel = Vector3.Angle(direction, hit.normal);
            float magnitude = Vector3.Magnitude(direction) * Mathf.Cos(Mathf.Deg2Rad * (180 - angel));
            direction += hit.normal * magnitude;
        }
        cameraTrans.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    private void GetDirection() {
        #region 加速移动
        if (Input.GetKeyDown(KeyCode.LeftShift)) moveSpeed *= shiftRate;
        if (Input.GetKeyUp(KeyCode.LeftShift)) moveSpeed /= shiftRate;
        #endregion
        #region 键盘移动
        // 复位
        speedForward = Vector3.zero;
        speedBack = Vector3.zero;
        speedLeft = Vector3.zero;
        speedRight = Vector3.zero;
        speedUp = Vector3.zero;
        speedDown = Vector3.zero;
        // 获取按键输入
        if (Input.GetKey(KeyCode.W)) speedForward = cameraTrans.forward;
        if (Input.GetKey(KeyCode.S)) speedBack = -cameraTrans.forward;
        if (Input.GetKey(KeyCode.A)) speedLeft = -cameraTrans.right;
        if (Input.GetKey(KeyCode.D)) speedRight = cameraTrans.right;
        if (Input.GetKey(KeyCode.E)) speedUp = Vector3.up;
        if (Input.GetKey(KeyCode.Q)) speedDown = Vector3.down;
        direction = speedForward + speedBack + speedLeft + speedRight + speedUp + speedDown;
        #endregion
        #region 鼠标旋转
        if (Input.GetMouseButton(1))
        {
            // 转相机朝向
            cameraTrans.RotateAround(cameraTrans.position, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);
            cameraTrans.RotateAround(cameraTrans.position, cameraTrans.right, -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
            // 转运动速度方向
            direction = V3RotateAround(direction, Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime);
            direction = V3RotateAround(direction, cameraTrans.right, -Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime);
         }
        #endregion
    }

    public Vector3 V3RotateAround(Vector3 source, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);// 旋转系数
        return q * source;// 返回目标点
    }
}
