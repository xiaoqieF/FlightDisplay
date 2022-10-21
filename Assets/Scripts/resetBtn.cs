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

    private GameObject F16_1;
    private GameObject F16_2;
    private GameObject redMissile1;
    private GameObject redMissile2;
    private GameObject blueMissile1;
    private GameObject blueMissile2;

    // Start is called before the first frame update
    void Start()
    {
        F16_1 = GameObject.Find("F16-1");
        F16_2 = GameObject.Find("F16-2");
        redMissile1 = GameObject.Find("RedMissile1");
        redMissile2 = GameObject.Find("RedMissile2");
        blueMissile1 = GameObject.Find("BlueMissile1");
        blueMissile2 = GameObject.Find("BlueMissile2");

        redAircraftTrans = GameObject.Find("RedAircraft").GetComponent<Transform>();
        redF16Trans = F16_1.GetComponent<Transform>();
        blueAircraftTrans = GameObject.Find("BlueAircraft").GetComponent<Transform>();
        blueF16Trans = F16_2.GetComponent<Transform>();

        redMissile1Trans = redMissile1.GetComponent<Transform>();
        redMissile2Trans = redMissile2.GetComponent<Transform>();
        blueMissile1Trans = blueMissile1.GetComponent<Transform>();
        blueMissile2Trans = blueMissile2.GetComponent<Transform>();
    }

    public void onReset() {
        redAircraftTrans.position = new Vector3(0.0f, -100.0f, 0.0f);
        blueAircraftTrans.position = new Vector3(0.0f, -200.0f, 0.0f);
        redMissile1Trans.position = new Vector3(0.0f, -300.0f, 0.0f);
        redMissile2Trans.position = new Vector3(0.0f, -400.0f, 0.0f);
        blueMissile1Trans.position = new Vector3(0.0f, -500.0f, 0.0f);
        blueMissile2Trans.position = new Vector3(0.0f, -600.0f, 0.0f);
        F16_1.SetActive(true);
        F16_2.SetActive(true);
        redMissile1.SetActive(true);
        redMissile2.SetActive(true);
        blueMissile1.SetActive(true);
        blueMissile2.SetActive(true);
    }

}
