using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class KeeperController : MonoBehaviour
{

    //　初期位置
    private Vector3 startPosition;
    //　目的地
    private Vector3 destination;
    //　巡回する位置
    [SerializeField]
    private Transform[] patrolPositions;
    //　次に巡回する位置
    private int nowPos = 0;

    void Start()
    {
        //　初期位置を設定
        startPosition = transform.position;
        //　巡回地点を設定
        var patrolParent = GameObject.Find("PatrolPosition1");
        for (int i = 0; i < patrolParent.transform.childCount; i++)
        {
            patrolPositions[i] = patrolParent.transform.GetChild(i);
        }
    }

    //　ランダムな位置の作成
    public void CreateRandomPosition()
    {
        //　ランダムなVector3の値を得る
        var randDestination = Random.insideUnitSphere * 8f;
        //　現在地にランダムな位置を足して目的地とする
        SetDestination(randDestination);
    }
    //　巡回地点を順に周る
    public void NextPosition()
    {
        SetDestination(patrolPositions[nowPos].position);
        nowPos++;
        if (nowPos >= patrolPositions.Length)
        {
            nowPos = 0;
        }
    }

    //　目的地を設定する
    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    //　目的地を取得する
    public Vector3 GetDestination()
    {
        return destination;
    }
}