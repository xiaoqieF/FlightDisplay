using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject freeCamera;
    public GameObject mainCamera;
    public GameObject redCamera;
    public GameObject blueCam;
    // Start is called before the first frame update
    void Start()
    {
        freeCamera = GameObject.Find("FreeCamera");
        mainCamera = GameObject.Find("MainCamera");
        redCamera = GameObject.Find("redCam");
        blueCam = GameObject.Find("blueCam");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToFree() {
        Debug.Log("change to free camera");
        freeCamera.SetActive(true);
        // mainCamera.SetActive(false); 
        redCamera.SetActive(false);
        blueCam.SetActive(false);
    }

    public void ChangeToRed() {
        freeCamera.SetActive(false);
        // mainCamera.SetActive(false); 
        redCamera.SetActive(true);
        blueCam.SetActive(false);
    }

    public void ChangeToBlue() {
        freeCamera.SetActive(false);
        // mainCamera.SetActive(false); 
        redCamera.SetActive(false);
        blueCam.SetActive(true);
    }
}
