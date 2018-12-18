using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float m_speed = 0.5f;  //移動速度
    public float m_rotation = 0.25f;        //回転速度

    private Transform m_target;  
    private Transform m_target1;  
    private Transform m_target2;
    private Transform m_target3;
    private Transform m_target4;

    //private float seed;

    NavMeshAgent m_agent;
    SimpleAnimation m_simpleAnimation = new SimpleAnimation();

    private static Vector3 m_position;
    private float m_patroldistance;
    private float m_targetdistance1;
    private float m_targetdistance2;
    private float m_targetdistance3;
    private float m_targetdistance4;

    //動物の種類を取得するstring
    private string name;

    //private string Playername;

    [SerializeField]
    float m_fieldOfView = 90f;    //ターゲットを見つけられる視野角

    //動物の捕食数をカウントするためのfloat型配列
    public static int [] Enemypoint = new int [4];
    public static int[ , ] Enemycounts = new int[4,3];

    void Awake()
    {
        
        
    }
    
    void Start()
    {
        m_simpleAnimation = GetComponent<SimpleAnimation>();

        m_agent = GetComponent<NavMeshAgent>();
        m_agent.enabled = true;

        m_target1 = GameObject.Find("Player1").transform;
        m_target2 = GameObject.Find("Player2").transform;
        m_target3 = GameObject.Find("Player3").transform;
        m_target4 = GameObject.Find("Player4").transform;

        Debug.Log("target1" + m_target1);
        Debug.Log("target2" + m_target2);
        Debug.Log("target3" + m_target3);
        Debug.Log("target4" + m_target4);

        name = transform.tag;

        m_simpleAnimation.CrossFade("Move", 0.2f);

        DoPatrol();
    }

    void Update()
    {
        m_simpleAnimation.CrossFade("Move", 0.2f);
        //        Debug.Log(NavMeshPathStatus.PathInvalid);
        m_patroldistance  = Vector3.Distance(this.m_agent.transform.position, m_position);
        m_targetdistance1 = Vector3.Distance(this.m_agent.transform.position, m_target1.transform.position);
        m_targetdistance2 = Vector3.Distance(this.m_agent.transform.position, m_target2.transform.position);
        m_targetdistance3 = Vector3.Distance(this.m_agent.transform.position, m_target3.transform.position);
        m_targetdistance4 = Vector3.Distance(this.m_agent.transform.position, m_target4.transform.position);

        //相手の位置と自分の位置の差ベクトルを求める
        Vector3 diff1 = m_target1.transform.position - transform.position;
        Vector3 diff2 = m_target2.transform.position - transform.position;
        Vector3 diff3 = m_target3.transform.position - transform.position;
        Vector3 diff4 = m_target4.transform.position - transform.position;

        float angle1 = Vector3.Angle(transform.forward, diff1);
        float angle2 = Vector3.Angle(transform.forward, diff2);
        float angle3 = Vector3.Angle(transform.forward, diff3);
        float angle4 = Vector3.Angle(transform.forward, diff4);

        if (m_patroldistance < 10f)
        {
            //seed = Random.Range(0, 21);
            DoPatrol();
        }

        if (angle1 < m_fieldOfView / 2f)
        {
            //Playerとの距離が5f以下になると逃げる
            if (m_targetdistance1 <= 5f)
            {
                m_target = m_target1;
                Move();
            }
            else if (m_targetdistance2 <= 5f)
            {
                m_target = m_target2;
                Move();
            }
            else if (m_targetdistance3 <= 5f)
            {
                m_target = m_target3;
                Move();
            }
            else if (m_targetdistance4 <= 5f)
            {
                m_target = m_target4;
                Move();
            }
            else if (m_patroldistance < 10f)
            {
               //seed = Random.Range(0, 21);
                DoPatrol();
            }
            else
            {
                if (m_agent.pathStatus != NavMeshPathStatus.PathInvalid)
                {
                    m_agent.SetDestination(m_position);
                }
                else
                {
                            Debug.Log(NavMeshPathStatus.PathInvalid);

                }
            }
           
        }
    }

    void Move()
    {
        m_simpleAnimation.CrossFade("Move", 0.2f);

        //ターゲットの方向を求める
        Vector3 vec = transform.position - m_target.position;    //m_target.position - transform.position;
        //ターゲットの方に向く
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), m_rotation);
        //進む方へ移動
        transform.Translate(Vector3.forward * m_speed);
    }

    public void DoPatrol()
    {
        if (m_agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            //navMeshAgentの操作
            
            var x = Random.Range(115f, 233f);
            var z = Random.Range(65f, 140f) ;
            m_position = new Vector3(x, 0, z);
            m_agent.SetDestination(m_position);
            Debug.Log(m_position);
        }
           
        m_simpleAnimation.CrossFade("Move", 0.2f);
    }
    

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {


            switch (col.gameObject.name)
            {
                case "Player1": switch (name)
                                {
                                    case "Enemy1":
                                    Enemycounts[0, 0] += 1;
                                    Enemypoint[0] += 100;
                                    Debug.Log("Enemypoint[0]:" + Enemypoint[0]);
                                    break;                                        
                                    case "Enemy2":
                                    Enemycounts[0, 1] += 1;
                                    Enemypoint[0] += 200;
                                    Debug.Log("Enemypoint[0]:" + Enemypoint[0]);
                                    break;
                                    case "Enemy3":
                                    Enemycounts[0, 2] += 1;
                                    Enemypoint[0] += 500;
                                    Debug.Log("Enemypoint[0]:" + Enemypoint[0]);
                                    break;
                                    default: break;
                                }
                break;

                case "Player2": switch (name)
                                {
                                    case "Enemy1":
                                    Enemycounts[1, 0] += 1;
                                    Enemypoint[1] += 100;
                                    Debug.Log("Enemypoint[1]:" + Enemypoint[1]);
                                    break;
                                    case "Enemy2":
                                    Enemycounts[1, 1] += 1;
                                    Enemypoint[1] += 200;
                                    Debug.Log("Enemypoint[1]:" + Enemypoint[1]);
                                    break;
                                    case "Enemy3":
                                    Enemycounts[1, 2] += 1;
                                    Enemypoint[0] += 500;
                                    Debug.Log("Enemypoint[1]:" + Enemypoint[1]);
                                    break;
                                    default: break;
                    }
                break;

                case "Player3": switch (name)
                                {
                                    case "Enemy1":
                                    Enemycounts[2, 0] += 1;
                                    Enemypoint[2] += 100;
                                    Debug.Log("Enemypoint[2]:" + Enemypoint[2]);
                                    break;
                                    case "Enemy2":
                                    Enemycounts[2, 1] += 1;
                                    Enemypoint[2] += 200;
                                    Debug.Log("Enemypoint[2]:" + Enemypoint[2]);
                                    break;
                                    case "Enemy3":
                                    Enemycounts[2, 2] += 1;
                                    Enemypoint[2] += 500;
                                    Debug.Log("Enemypoint[2]:" + Enemypoint[2]);
                                    break;
                                    default: break;
                    }
                break;

                case "Player4": switch (name)
                                {
                                    case "Enemy1":
                                    Enemycounts[3, 0] += 1;
                                    Enemypoint[3] += 100;
                                    Debug.Log("Enemypoint[3]:" + Enemypoint[3]);
                                    break;
                                    case "Enemy2":
                                    Enemycounts[3, 1] += 1;
                                    Enemypoint[3] += 200;
                                    Debug.Log("Enemypoint[3]:" + Enemypoint[3]);
                                    break;
                                    case "Enemy3":
                                    Enemycounts[3, 2] += 1;
                                    Enemypoint[3] += 500;
                                    Debug.Log("Enemypoint[3]:" + Enemypoint[3]);
                                    break;
                                    default: break;
                    }
                break;

                default: break;

            }
            
            Destroy(this.gameObject);
        }

        if(col.gameObject.tag == "Enemy1" || col.gameObject.tag == "Enemy2" || col.gameObject.tag == "Enemy3")
        {
            Move();
        }
    }
}

