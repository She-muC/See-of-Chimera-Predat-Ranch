using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject m_target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //カメラの移動
        Vector3 pos = m_target.transform.position + (-m_target.transform.forward * 6f); //戦車の６ｍ後ろにカメラを移動
        pos.y += 3f;                        //高さを３ｍ上げる
        pos = Vector3.Lerp(transform.position, pos, 0.1f);  //カメラの移動を遅らせる
        transform.position = pos;           //変更した値を反映

        //目標のほうを向く
        transform.LookAt(m_target.transform.position);

    }
}
