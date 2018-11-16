using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    public PlayerMovementController m_playermovementController; //戦車の操作系

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        //バーチャルパッドスライド時の移動処理
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        m_playermovementController.Forward(vertical);

        m_playermovementController.Side(horizontal);

        //スキルボタン押下時の処理
        CrossPlatformInputManager.GetButtonDown("Skill1");



    }
}

