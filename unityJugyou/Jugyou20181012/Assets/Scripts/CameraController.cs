using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    GameObject m_target1;

    [SerializeField]
    GameObject m_target2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //１Pと２Pの距離を調べて中心を求める
        float distance = Vector3.Distance(m_target1.transform.position, m_target2.transform.position);

        //１Pと２Pのベクトルを求める
        Vector3 axis = m_target2.transform.position - m_target1.transform.position;

        Vector3 center = m_target1.transform.position + ()
	}
}
