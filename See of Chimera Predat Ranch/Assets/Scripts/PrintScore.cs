using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PrintScore : MonoBehaviour
{
    public Text Score1;
    public Text Score2;
    public Text Score3;
    public Text Score4;

    public Text Winner;

    private int [] winner = new int [4];
    private int max = 0;
    private int count = 0;


    void Start ()
    {
        Score1.text = "1P:" + " " + EnemyController.Enemypoint[0].ToString();
        Score2.text = "2P:" + " " + EnemyController.Enemypoint[1].ToString();
        Score3.text = "3P:" + " " + EnemyController.Enemypoint[2].ToString();
        Score4.text = "4P:" + " " + EnemyController.Enemypoint[3].ToString();

        max =  Mathf.Max(EnemyController.Enemypoint[0], EnemyController.Enemypoint[1], EnemyController.Enemypoint[2], EnemyController.Enemypoint[3]);

        for(int i = 0; i < 4; i++)
        {
            if(max == EnemyController.Enemypoint[i])
            {
                winner[count] = i + 1;
                count++;
            }
        }

        if(count >= 2)
        {
            switch (count)
            {
                case 2: Winner.text = winner[0] + "P," + winner[1] + "P" + "Win!";
                break;

                case 3: Winner.text = winner[0] + "P," + winner[1] + "P" + winner[2] + "P" + "Win!";
                break;

                case 4: Winner.text = "Draw!!";
                break;

                default :
                break;
            }
        }
        else
        {
            Winner.text = winner[0] + "P  Win!";
        }


        Debug.Log("Result 1P:" + EnemyController.Enemypoint[0]);
        Debug.Log("Result 2P:" + EnemyController.Enemypoint[1]);
        Debug.Log("Result 3P:" + EnemyController.Enemypoint[2]);
        Debug.Log("Result 4P:" + EnemyController.Enemypoint[3]);
    }
}
