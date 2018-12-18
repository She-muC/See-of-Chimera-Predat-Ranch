using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick(int num)
    {
        switch(num)
        {
            case 1 :            
            SceneManager.LoadScene("Farm");
            break;

            case 2:
            SceneManager.LoadScene("Result");
            break;

            case 3:
            SceneManager.LoadScene("Title");
            break;

            case 4:
            SceneManager.LoadScene("Select");
            break;

            default:
            break;
        }
        
    }
}
