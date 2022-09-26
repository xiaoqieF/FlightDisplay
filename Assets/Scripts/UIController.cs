// 控制UI面板是否显示

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool enable = true;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("Panel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            enable = !enable;
            panel.SetActive(enable);
        }
    }
}
