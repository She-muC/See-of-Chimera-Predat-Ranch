using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public PlayerMovementController m_playermovementController;

    SimpleAnimation m_simpleAnimation = new SimpleAnimation();

    

    void Start()
    {
        m_simpleAnimation = GetComponent<SimpleAnimation>();

        m_simpleAnimation.CrossFade("Default", 0.2f);
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_playermovementController.Forward();
            m_simpleAnimation.CrossFade("Walk", 0.2f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            m_playermovementController.Back();
            m_simpleAnimation.CrossFade("Walk", 0.2f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_playermovementController.Left();
            m_simpleAnimation.CrossFade("Walk", 0.2f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_playermovementController.Right();
            m_simpleAnimation.CrossFade("Walk", 0.2f);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            m_simpleAnimation.CrossFade("Default", 0.2f);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            m_simpleAnimation.CrossFade("Default", 0.2f);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            m_simpleAnimation.CrossFade("Default", 0.2f);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            m_simpleAnimation.CrossFade("Default", 0.2f);
        }
    }
}

