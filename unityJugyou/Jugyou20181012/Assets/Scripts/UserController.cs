using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserController : MonoBehaviour {

    PlayerController m_playerController;

    bool m_isAttacking;

    float m_attackintervalTimer;

    //上キーが押された
    bool m_isRunning;

    float m_time0fKeyUp;

    // Use this for initialization
    void Start () {

        m_playerController = GetComponent<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {

        //前後移動
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!m_isRunning)
            {
                if(Time.time - m_time0fKeyUp < 0.3f)
                {
                    //前進キーが押されてから0.3秒後にもう一度押されたら走る
                    m_isRunning = true; 
                }
            }

            if (m_isRunning)
            {
                m_playerController.Forward = 5.0f; //走っているなら
            }
            else
            {
                m_playerController.Forward = 1.0f;  //歩いているなら
            }

            //m_playerController.Forward = 1.0f * 2f;　//アナログ値　*　移動量(m/s)←最大値
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            m_playerController.Back = 1.0f;
            m_isRunning = false;
        }
        else
        {
            m_isRunning = false;
        }

        //上キーが話された
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            m_time0fKeyUp = Time.time;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_playerController.Left = 2.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_playerController.Right = 2.0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            m_playerController.Up = 2.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_playerController.Down = 2.0f;
        }



        if (!m_isAttacking && m_attackintervalTimer <= 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                UnityAction action = AttackFinished;
                m_playerController.PlayAnimation("Attack", action);
                m_isAttacking = true;
            }

            else if (Input.GetKey(KeyCode.Z))
            {
                UnityAction action = AttackFinished;
                m_playerController.PlayAnimation("Attack2", action);
                m_isAttacking = true;
            }
        }
        else
        {
            m_attackintervalTimer -= Time.deltaTime;
        }
    }

    /// <summary>
    /// 攻撃が完了したら呼ばれる
    /// </summary>
    public void AttackFinished()
    {
        m_attackintervalTimer = 0.2f;

        m_isAttacking = false;

 //       Debug.Log("AttackFinished");
    }
}
