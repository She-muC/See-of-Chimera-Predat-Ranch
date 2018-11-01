using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class KeeperController : MonoBehaviour
{
    [SerializeField]
    GameObject m_target;
    NavMeshAgent m_navmeshAgent;

    [SerializeField]
    float m_distance = 3f;        //ターゲットを見つけられる距離

    [SerializeField]
    float m_fieldOfView = 90f;    //ターゲットを見つけられる視野角

    //　初期位置
    private Vector3 startPosition;
    //　目的地
    private Vector3 destination;
    //　巡回する位置
    [SerializeField]
    private Transform[] patrolPositions;
    //　次に巡回する位置
    private int nowPos = 0;

    enum MoveState
    {
        Patrol, //ルート巡回
        Chase,  //追跡
    }
    MoveState m_moveState = MoveState.Patrol;     //移動状態


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

    void Update()
    {
        if (Vector3.Distance(transform.position, m_target.transform.position) < m_distance)
        {
            //相手の位置と自分の位置の差ベクトルを求める
            Vector3 diff = m_target.transform.position - transform.position;

            float angle = Vector3.Angle(transform.forward, diff);
            if (angle < m_fieldOfView / 2f)
            {
                m_moveState = MoveState.Chase;  //追跡モードに切り替え
            }
        }
    }

    void Chase()
    {

        //NavMeshが準備できているなら
        if (m_navmeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            //NavMeshAgentに目標地をセット
            m_navmeshAgent.SetDestination(m_target.transform.position);
  
        }
    }
}