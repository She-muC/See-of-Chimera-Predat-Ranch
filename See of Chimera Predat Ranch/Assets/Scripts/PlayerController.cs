using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //プレイヤータイプの切り替え
    public enum PlayerType
    {
        Player1,
        Player2,
    }
    public PlayerType m_playerType = PlayerType.Player1;

    public PlayerMovementController m_playermovementController;

    SimpleAnimation simpleAnimation = new SimpleAnimation();

    UnityEvent m_unityEvent = new UnityEvent();

    bool m_isPlayingAnimation;	

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_playerType)
        {
            case PlayerType.Player1:
                if (Input.GetKey(KeyCode.W))
                {
                    m_playermovementController.Forward();
                    simpleAnimation.CrossFade("Run", 0.2f);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    m_playermovementController.Back();
                    simpleAnimation.CrossFade("Walk", 0.2f);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    m_playermovementController.Left();
                    simpleAnimation.CrossFade("Walk", 0.2f);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    m_playermovementController.Right();
                    simpleAnimation.CrossFade("Walk", 0.2f);
                }
                else if (Input.GetKey(KeyCode.Space))
                {
                    simpleAnimation.CrossFade("Jump", 0.2f);
                }
                break;

            case PlayerType.Player2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    m_playermovementController.Forward();
                    simpleAnimation.Play("Run");
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    m_playermovementController.Back();
                    simpleAnimation.Play("Walk");
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    m_playermovementController.Left();
                    simpleAnimation.Play("Walk");
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    m_playermovementController.Right();
                    simpleAnimation.Play("Walk");
                }
                break;
        }

    }

    public void PlayAnimation(string value, UnityAction callbackMethod)
    {
        m_unityEvent.AddListener(callbackMethod);   // コールバック関数の登録
        simpleAnimation.CrossFade(value, 0.2f);
        m_isPlayingAnimation = true;
    }

    public void OnAnimationFinished()
    {
        m_unityEvent.Invoke();              // 登録されているコールバック関数の呼び出し
        m_unityEvent.RemoveAllListeners();  // 登録されていた関数を削除
        m_isPlayingAnimation = false;       // フラグをfalseに戻す
    }
}

