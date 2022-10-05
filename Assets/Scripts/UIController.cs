// 控制UI面板是否显示

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool enable = true;
    public CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            enable = !enable;
            if (enable) {
                canvas.alpha = 1;
                canvas.interactable = true;
                canvas.blocksRaycasts = true;
            } else {
                canvas.alpha = 0;
                canvas.interactable = false;
                canvas.blocksRaycasts = false;
            }
        }
    }
}
