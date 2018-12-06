using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalCotroller : MonoBehaviour
{
    public float m_speed = 0.5f;  //移動速度
    public float m_rotation = 0.25f;        //回転速度
    public Transform m_target;  //追いかけるオブジェクト
    NavMeshAgent m_agent;

    private static Vector3 m_position;
    private float m_patroldistance;
    private float m_targetdistance;

    //動物の種類を取得するstring
    private string name;

    [SerializeField]
    float m_fieldOfView = 90f;    //ターゲットを見つけられる視野角

    //動物の捕食数をカウントするためのfloat型配列
    public static int [] animalpoint = new int [3];

    void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        name = transform.tag;

        DoPatrol();
    }

    void Update()
    {
        m_patroldistance = Vector3.Distance(this.m_agent.transform.position, m_position);
        m_targetdistance = Vector3.Distance(this.m_agent.transform.position, m_target.transform.position);

        //相手の位置と自分の位置の差ベクトルを求める
        Vector3 diff = m_target.transform.position - transform.position;

        float angle = Vector3.Angle(transform.forward, diff);
        if (angle < m_fieldOfView / 2f)
        {
            //Playerとの距離が30f以下になると逃げる
            if (m_targetdistance <= 5f)
            {
                Move();
            }
            else if (m_patroldistance < 2f)
            {
                DoPatrol();
            }
            else
            {
                m_agent.SetDestination(m_position);
            }
           
        }
    }

    void Move()
    {
        //ターゲットの方向を求める
        Vector3 vec = transform.position - m_target.position;    //m_target.position - transform.position;
        //ターゲットの方に向く
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), m_rotation);
        //進む方へ移動
        transform.Translate(Vector3.forward * m_speed);
    }

    public void DoPatrol()
    {
        var x = Random.Range(115f, 233f);
        var z = Random.Range(65f, 140f);
        m_position = new Vector3(x, 0, z);
        m_agent.SetDestination(m_position);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            switch (name)
            {
                case "animal1": animalpoint[0]++;
                    Debug.Log("animalpoint[0]:" + animalpoint[0]);
                    break;

                case "animal2":
                animalpoint[1]++;
                    Debug.Log("animalpoint[1]:" + animalpoint[1]);
                    break;

                case "animal3":
                animalpoint[2]++;
                    Debug.Log("animalpoint[2]:" + animalpoint[2]);
                break;
            }

            Destroy(this.gameObject);
        }
    }
}

