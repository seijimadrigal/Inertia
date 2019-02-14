using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

    public GameObject levelimage;
    // Use this for initialization

    public void LoadScene(int level)
    {
        levelimage.SetActive(true);
        Application.LoadLevel(level);
    }
}

