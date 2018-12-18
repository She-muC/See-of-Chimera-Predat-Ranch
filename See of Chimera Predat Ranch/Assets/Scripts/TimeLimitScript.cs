﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimitScript : MonoBehaviour {

    [SerializeField]
    private int minute;

    [SerializeField]
    private float seconds;
    //前のupdate時の秒数
    private float oldSeconds;
    //たいまー表示用テキスト
    private Text timerText;

    [SerializeField]
    Text LimitCount;

    [SerializeField]
    Text timeUp;

    public Text Score1P;
    public Text Score2P;
    public Text Score3P;
    public Text Score4P;

    // Use this for initialization
    void Start ()
    {
        
        /*minute = 0;

        seconds = 10;*/

        oldSeconds = 0;

        LimitCount.enabled = false;

        timeUp.enabled = false;

        timerText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        seconds -= Time.deltaTime;

        if(seconds <= 0)
        {
            minute--;
            seconds = seconds + 60;

        }

        //値が変わった時だけテキストUIを更新
        if((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("TimeLimit 00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;

        //残り5秒になったら残り時間を2秒表示
        if(minute <= 0 && (int)seconds <= 10)
        {
            LimitCount.enabled = true;

            Score1P.enabled = false;
            Score2P.enabled = false;
            Score3P.enabled = false;
            Score4P.enabled = false;

            if ((int)seconds <= 8)
            {
                LimitCount.enabled = false;
            }
        }
        //タイムアップを表示後リザルト画面へ遷移
        if(minute <= 0 && (int)seconds <= 0)
        {
            timeUp.enabled = true;
            
            Invoke("SceneTransition", 3f);

            timerText.enabled = false;
        }
    }

    void SceneTransition()
    {
        SceneManager.LoadScene("Result");
    }
}
