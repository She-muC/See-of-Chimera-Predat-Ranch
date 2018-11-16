using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{

    public float m_speed = 3f;
    public float m_angle = 90f;

    float m_forward = 0;
    float m_side = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //移動処理-----------------------------------------------------
        //現在位置を取得
        Vector3 pos = transform.position;


            //transform.forwardは自分が向いている方向を表すベクトル
            pos += transform.forward * m_forward * m_speed * Time.deltaTime;



        //変更した値を反映
        transform.position = pos;
        //移動処理-----------------------------------------------------

        //旋回処理-----------------------------------------------------
        //現在の回転情報を取得
        Vector3 rot = transform.rotation.eulerAngles;


            rot.y += m_angle * m_side * Time.deltaTime;

        //変更した値を反映
        transform.rotation = Quaternion.Euler(rot);

        //旋回処理-----------------------------------------------------


        //変更したフラグを元に戻す
        m_forward = 0;
        m_side = 0;
    }

    //前に進む
    public void Forward(float value)
    {
        m_forward = value;
    }


    //右回転
    public void Side(float value)
    {
        m_side = value;
    }



}