// 导弹命中飞行器脚本

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRedHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter(Collider other) {
        // 检测到和蓝方碰撞，则摧毁飞机和导弹
        if (other.gameObject.name.Contains("RedMissile")) {
            Debug.Log("OnTriggerEnter: RedMissile");
            var exp = GetComponent<ParticleSystem>();
            exp.Play();
            // this.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
