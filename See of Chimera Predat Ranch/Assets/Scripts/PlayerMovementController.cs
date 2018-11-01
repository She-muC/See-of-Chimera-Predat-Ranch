using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{

    public float m_speed = 3f;
    public float m_angle = 90f;

    bool m_forward = false;
    bool m_back = false;
    bool m_left = false;
    bool m_right = false;

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

        //前進処理
        if (m_forward == true)
        {
            //transform.forwardは自分が向いている方向を表すベクトル
            pos += transform.forward * m_speed * Time.deltaTime;
        }
        //後退処理
        else if (m_back == true)
        {
            //transform.forwardは自分が向いている方向を表すベクトル
            pos -= transform.forward * m_speed * Time.deltaTime;
        }

        //変更した値を反映
        transform.position = pos;
        //移動処理-----------------------------------------------------

        //旋回処理-----------------------------------------------------
        //現在の回転情報を取得
        Vector3 rot = transform.rotation.eulerAngles;

        if (m_right == true)
        {
            rot.y += m_angle * Time.deltaTime;
        }

        if (m_left == true)
        {
            rot.y -= m_angle * Time.deltaTime;
        }

        //変更した値を反映
        transform.rotation = Quaternion.Euler(rot);

        //旋回処理-----------------------------------------------------


        //変更したフラグを元に戻す
        m_forward = false;
        m_back = false;
        m_left = false;
        m_right = false;
    }

    //前に進む
    public void Forward()
    {
        m_forward = true;
    }
    //後ろに進む
    public void Back()
    {
        m_back = true;
    }
    //右回転
    public void Right()
    {
        m_right = true;
    }
    //左回転
    public void Left()
    {
        m_left = true;
    }


}