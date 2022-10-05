// 自由视角相机

using UnityEngine;

public class HalfFreeCamera : MonoBehaviour
{
    public Transform cameraTrans;

    public float moveSpeed = 20.0f;
    public float rotateSpeed = 90.0f;

    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        cameraTrans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirection();
        cameraTrans.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    private void GetDirection() {
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
