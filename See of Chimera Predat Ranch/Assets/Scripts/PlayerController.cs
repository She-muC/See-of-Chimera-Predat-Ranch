using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public PlayerMovementController m_playermovementController;

    SimpleAnimation m_simpleAnimation = new SimpleAnimation();

    private string name;

    //キーバインド設定
    public KeyCode m_1PforwardKey = KeyCode.W;   // 前移動キー
    public KeyCode m_1PbackKey = KeyCode.S;   // 後ろ移動キー
    public KeyCode m_1PleftKey = KeyCode.A;         // 左旋回移動キー
    public KeyCode m_1PRightKey = KeyCode.D;           // 右旋回移動キー
    //public KeyCode m_1PattackKey = KeyCode.E;            // 捕食キー

    public KeyCode m_2PforwardKey = KeyCode.UpArrow;   // 前移動キー
    public KeyCode m_2PbackKey = KeyCode.DownArrow;   // 後ろ移動キー
    public KeyCode m_2PleftKey = KeyCode.LeftArrow;         // 左旋回移動キー
    public KeyCode m_2PRightKey = KeyCode.RightArrow;           // 右旋回移動キー
    //public KeyCode m_2PattackKey = KeyCode.L;            // 捕食キー

    public KeyCode m_3PforwardKey = KeyCode.Keypad5;   // 前移動キー
    public KeyCode m_3PbackKey = KeyCode.Keypad2;   // 後ろ移動キー
    public KeyCode m_3PleftKey = KeyCode.Keypad1;         // 左旋回移動キー
    public KeyCode m_3PRightKey = KeyCode.Keypad3;           // 右旋回移動キー
    //public KeyCode m_3PattackKey = KeyCode.Keypad4;            // 捕食キー

    public KeyCode m_4PforwardKey = KeyCode.I;   // 前移動キー
    public KeyCode m_4PbackKey = KeyCode.K;   // 後ろ移動キー
    public KeyCode m_4PleftKey = KeyCode.J;         // 左旋回移動キー
    public KeyCode m_4PRightKey = KeyCode.L;           // 右旋回移動キー
    //public KeyCode m_4PattackKey = KeyCode.L;            // 捕食キー



    void Start()
    {
        name = this.transform.name;

        m_simpleAnimation = GetComponent<SimpleAnimation>();

        m_simpleAnimation.CrossFade("Default", 0.2f);

        Debug.Log(name);
    }

    
    void Update()
    {
        if(name == "Player1")
        {
            if (Input.GetKey(m_1PforwardKey))
            {
                m_playermovementController.Forward();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            else if (Input.GetKey(m_1PbackKey))
            {
                m_playermovementController.Back();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            if (Input.GetKey(m_1PleftKey))
            {
                m_playermovementController.Left();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            else if (Input.GetKey(m_1PRightKey))
            {
                m_playermovementController.Right();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }

            if (Input.GetKeyUp(m_1PforwardKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_1PbackKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_1PleftKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_1PRightKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }

        }

        if (name == "Player2")
        {
            if (Input.GetKey(m_2PforwardKey))
            {
                m_playermovementController.Forward();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            else if (Input.GetKey(m_2PbackKey))
            {
                m_playermovementController.Back();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            if (Input.GetKey(m_2PleftKey))
            {
                m_playermovementController.Left();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            else if (Input.GetKey(m_2PRightKey))
            {
                m_playermovementController.Right();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }

            if (Input.GetKeyUp(m_2PforwardKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_2PbackKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_2PleftKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_2PRightKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
        }

        if (name == "Player3")
        {
            if (Input.GetKey(m_3PforwardKey))
            {
                m_playermovementController.Forward();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            else if (Input.GetKey(m_3PbackKey))
            {
                m_playermovementController.Back();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            if (Input.GetKey(m_3PleftKey))
            {
                m_playermovementController.Left();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            else if (Input.GetKey(m_3PRightKey))
            {
                m_playermovementController.Right();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }

            if (Input.GetKeyUp(m_3PforwardKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_3PbackKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_3PleftKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_3PRightKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
        }

        if (name == "Player4")
        {
            if (Input.GetKey(m_4PforwardKey))
            {
                m_playermovementController.Forward();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            else if (Input.GetKey(m_4PbackKey))
            {
                m_playermovementController.Back();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            if (Input.GetKey(m_4PleftKey))
            {
                m_playermovementController.Left();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }
            else if (Input.GetKey(m_4PRightKey))
            {
                m_playermovementController.Right();
                m_simpleAnimation.CrossFade("Walk", 0.2f);
            }

            if (Input.GetKeyUp(m_4PforwardKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_4PbackKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_4PleftKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
            else if (Input.GetKeyUp(m_4PRightKey))
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }
        }
    }
}

