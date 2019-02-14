using UnityEngine;
using System.Collections;

public class CameraTrans : MonoBehaviour
{
    public Camera MainCamera;
    public Camera Camera;
    // Use this for initialization

    void Start()
    {

        MainCamera.enabled = true;
        Camera.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MainCamera.enabled = !MainCamera.enabled;
            Camera.enabled = !Camera.enabled;
        }
    }
}

