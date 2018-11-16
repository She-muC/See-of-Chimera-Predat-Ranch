using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public bool DontDestroyEnable = true;


	// Use this for initialization
	void Start ()
    {
        if (DontDestroyEnable)
        {
            DontDestroyOnLoad(this);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
