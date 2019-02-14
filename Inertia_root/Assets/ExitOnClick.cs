using UnityEngine;
using System.Collections;

public class ExitOnClick : MonoBehaviour {

	// Use this for initialization
	public void LoadScene(int level)
    {
        Application.Quit();
    }
}
