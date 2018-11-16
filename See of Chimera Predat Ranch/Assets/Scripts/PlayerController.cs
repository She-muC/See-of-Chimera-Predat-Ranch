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
                    
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    m_playermovementController.Back();
                    
                }
                if (Input.GetKey(KeyCode.A))
                {
                    m_playermovementController.Left();
                    
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    m_playermovementController.Right();
                    
                }
                break;

            case PlayerType.Player2:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    m_playermovementController.Forward();
                    
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    m_playermovementController.Back();
                    
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    m_playermovementController.Left();
                    
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    m_playermovementController.Right();
                    
                }
                break;
        }

    }
}

