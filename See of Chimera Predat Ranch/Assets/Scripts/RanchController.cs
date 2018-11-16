using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   //追加
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RanchController : MonoBehaviour
{

    [SerializeField]
    GameObject[] m_routes;               //目標地点
    int m_routeNo;              //何番目の目標地点に向かわせるか

    [SerializeField]
    GameObject m_target;
    bool m_isNavSet;
    NavMeshAgent m_navmeshAgent;         //NavMeshAgentコンポーネント
    PlayerController m_playerController;     //アニメーション担当

    SimpleAnimation m_simpleAnimation = new SimpleAnimation();

    [SerializeField]
    float m_walkingSpeed = 3f;    //歩くスピード

    [SerializeField]
    float m_runningSpeed = 6f;    //走るスピード

    [SerializeField]
    float m_distance = 3f;        //ターゲットを見つけられる距離

    [SerializeField]
    float m_fieldOfView = 90f;    //ターゲットを見つけられる視野角

    float m_catchAnimationTimer;    //捕まえるアニメーションが連続再生されないためのタイマー


    /// <summary>
    /// 移動状態
    /// </summary>

    enum MoveState
    {
        Patrol, //ルート巡回
        Chase,  //追跡
    }
    MoveState m_moveState = MoveState.Patrol;     //移動状態


    // Use this for initialization
    void Start()
    {
        //自分についているNavMeshAgentコンポーネントを取得
        m_navmeshAgent = GetComponent<NavMeshAgent>();

        m_playerController = GetComponent<PlayerController>();

        m_simpleAnimation = GetComponent<SimpleAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_moveState)
        {
            case MoveState.Patrol:
                {
                    m_simpleAnimation.CrossFade("Walk", 0.2f);
                    Patrol();
                }
                break;
            case MoveState.Chase:
                {
                    m_simpleAnimation.CrossFade("Walk", 0.2f);
                    Chase();
                }
                break;
        }

        //経路計算をさせるためにフラグを変更
    }

    /// <summary>
    /// ルート巡回
    /// </summary>
    void Patrol()
    {
        //キャラクターアニメーション
        //NacMeshAgentの移動ベクトルの長さをアニメーションの値として利用
      //  m_playerController.Forward = m_navmeshAgent.velocity.magnitude;

        //目標地点がセットされていないならセットを試みる
        if (!m_isNavSet)
        {
            //NavMeshが準備できているなら
            if (m_navmeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
            {
                //NavMeshAgentに目標地をセット
                m_navmeshAgent.SetDestination(m_routes[m_routeNo].transform.position);
                m_isNavSet = true;
                m_navmeshAgent.speed = m_walkingSpeed;
            }
        }

        if (!m_navmeshAgent.pathPending && m_navmeshAgent.remainingDistance < m_navmeshAgent.radius * 2f)
        {
            m_routeNo++;                           //次の目的地ナンバーにする
            if (m_routeNo >= m_routes.Length)      //上限チェック
            {
                m_routeNo = 0;                     //経路計算をさせるためにフラグを変更
            }
            m_isNavSet = false;
        }

        //追跡に切り替えるための判定
        //ターゲットとの距離を調べる
        if (Vector3.Distance(transform.position, m_target.transform.position) < m_distance)
        {
            //相手の位置と自分の位置の差ベクトルを求める
            Vector3 diff = m_target.transform.position - transform.position;

            float angle = Vector3.Angle(transform.forward, diff);
            if (angle < m_fieldOfView / 2f)
            {
                Debug.Log("追跡");
                m_moveState = MoveState.Chase;  //追跡モードに切り替え
            }
        }
        
    }

    /// <summary>
    /// 追跡
    /// </summary>
    void Chase()
    {

        //NavMeshが準備できているなら
        if (m_navmeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            //NavMeshAgentに目標地をセット
            m_navmeshAgent.SetDestination(m_target.transform.position);
            m_navmeshAgent.speed = m_runningSpeed;
        }

        if (m_catchAnimationTimer > 0)
        {
            m_catchAnimationTimer -= Time.deltaTime;
            
        }
        else
        {
            //捕まえるアニメーションの再生
            if (Vector3.Distance(transform.position, m_target.transform.position) < 5f)
            { 
                Debug.Log("捕獲");
                    m_simpleAnimation.Play("Attack");
                    UnityAction action = OnCatchAnimationFinished;  //コールバック関数の登録
            }
        }

        if (Vector3.Distance(transform.position, m_target.transform.position) > m_distance)
        {
            //相手の位置と自分の位置の差ベクトルを求める
            Vector3 diff = m_target.transform.position - transform.position;

            float angle = Vector3.Angle(transform.forward, diff);
            if (angle > m_fieldOfView / 2f)
            {
                Debug.Log("巡回");
                m_moveState = MoveState.Patrol;  //巡回モードに切り替え
            }
        }

    }


    /// <summary>
    /// 捕まえるアニメーションが終了したときに呼ばれる関数
    /// </summary>
    void OnCatchAnimationFinished()
    {
        m_catchAnimationTimer = 0.5f;       //連続で再生されないようにタイマーをセット
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Result");
        }
    }

}