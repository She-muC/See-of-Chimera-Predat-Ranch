using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Score1P;
    public Text Score1P2;

    public Text Score2P;
    public Text Score2P2;

    public Text Score3P;
    public Text Score3P2;

    public Text Score4P;
    public Text Score4P2;

    // Update is called once per frame
    void Update ()
    {
        Score1P.text = "1P Score:" + EnemyController.Enemypoint[0];
        Score1P2.text = "Enemy1:" + EnemyController.Enemycounts[0,0] + "Enemy2:" + EnemyController.Enemycounts[0, 1] + "Enemy3:" + EnemyController.Enemycounts[0, 2];

        Score2P.text = "2P Score:" + EnemyController.Enemypoint[1];
        Score2P2.text = "Enemy1:" + EnemyController.Enemycounts[1, 0] + "Enemy2:" + EnemyController.Enemycounts[1, 1] + "Enemy3:" + EnemyController.Enemycounts[1, 2];

        Score3P.text = "3P Score:" + EnemyController.Enemypoint[2];
        Score3P2.text = "Enemy1:" + EnemyController.Enemycounts[2, 0] + "Enemy2:" + EnemyController.Enemycounts[2, 1] + "Enemy3:" + EnemyController.Enemycounts[2, 2];

        Score4P.text = "4P Score:" + EnemyController.Enemypoint[3];
        Score4P2.text = "Enemy1:" + EnemyController.Enemycounts[3, 0] + "Enemy2:" + EnemyController.Enemycounts[3, 1] + "Enemy3:" + EnemyController.Enemycounts[3, 2];
    }
}
