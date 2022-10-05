using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetBtn : MonoBehaviour
{
    public Transform redAircraftTrans;
    public Transform blueAircraftTrans;
    public Transform redF16Trans;
    public Transform blueF16Trans;
    public Transform redMissile1Trans;
    public Transform redMissile2Trans;
    public Transform blueMissile1Trans;
    public Transform blueMissile2Trans;
    // Start is called before the first frame update
    void Start()
    {
        redAircraftTrans = GameObject.Find("RedAircraft").GetComponent<Transform>();
        redF16Trans = GameObject.Find("F16-1").GetComponent<Transform>();
        blueAircraftTrans = GameObject.Find("BlueAircraft").GetComponent<Transform>();
        blueF16Trans = GameObject.Find("F16-2").GetComponent<Transform>();

        redMissile1Trans = GameObject.Find("RedMissile1").GetComponent<Transform>();
        redMissile2Trans = GameObject.Find("RedMissile2").GetComponent<Transform>();
        blueMissile1Trans = GameObject.Find("BlueMissile1").GetComponent<Transform>();
        blueMissile2Trans = GameObject.Find("BlueMissile2").GetComponent<Transform>();
    }

    public void onReset() {
        redAircraftTrans.position = new Vector3(0.0f, -1.0f, 0.0f);
        blueAircraftTrans.position = new Vector3(0.0f, -1.0f, 0.0f);
        redMissile1Trans.position = new Vector3(0.0f, -1.0f, 0.0f);
        redMissile2Trans.position = new Vector3(0.0f, -1.0f, 0.0f);
        blueMissile1Trans.position = new Vector3(0.0f, -1.0f, 0.0f);
        blueMissile2Trans.position = new Vector3(0.0f, -1.0f, 0.0f);
    }

}
