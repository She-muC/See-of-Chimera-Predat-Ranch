using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    GameObject m_target;    //対戦相手

    [SerializeField]
    BoxCollider m_SwordAttackcollider;


    [SerializeField]
    bool m_animationOnly;       //アニメーションだけ行い移動処理は行わない

    float m_forward = 0f;   //前進用変数
    float m_back = 0f;   //後退用変数
    float m_left = 0f;   //左移動用変数
    float m_right = 0f;   //右移動用変数
    float m_up = 0f;        //上移動
    float m_down = 0f;      //下移動

    bool m_isPlayingAnimation;  //強制アニメ―ション中か

    UnityEvent m_unityEvent = new UnityEvent();   //コールバックイベント

    SimpleAnimation m_simpleAnimation;  //アニメーション管理変数

    Rigidbody m_rigitBody;

	// Use this for initialization
	void Start () {

        m_simpleAnimation = GetComponent<SimpleAnimation>();

        m_rigitBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Move();

    }

    ///<summary>
    ///移動
    ///</summary>>
    void Move()
    {
        if (!m_animationOnly)
        {
            //前移動
            transform.position += transform.forward * m_forward * Time.deltaTime;

            //後移動
            transform.position -= transform.forward * m_back * Time.deltaTime;

            //左移動
            transform.position += transform.right * m_left * Time.deltaTime;
            
            //右移動
            transform.position -= transform.right * m_right * Time.deltaTime;

            //上移動
            transform.position += Vector3.up * m_up * Time.deltaTime;

            //下移動
            transform.position -= transform.up * m_down * Time.deltaTime;


            //            Vector3 rot = transform.rotation.eulerAngles;
            //          rot.y += m_right * Time.deltaTime;      //右回転
            //            rot.y -= m_left * Time.deltaTime;       //左回転
            //            transform.rotation = Quaternion.Euler(rot);
        }

        //「歩く」と「アイドル」のアニメ―ション切り替え
        if (!m_isPlayingAnimation)                      //強制アニメーション中でなければ
        {
            //相手の方を向く
            transform.LookAt(m_target.transform);

            //Y軸以外の開店をなくす
            Vector3 rot = transform.rotation.eulerAngles;
            rot.x = 0;
            rot.z = 0;
            transform.rotation = Quaternion.Euler(rot);

            //歩くとアイドルのアニメーション切り替え
            if (m_forward > 0f || m_back > 0 || m_left > 0 || m_right > 0)
            {
                if (m_forward > 3f)
                {
                    m_simpleAnimation.CrossFade("Run", 0.2f);
                }
                else
                {
                    m_simpleAnimation.CrossFade("Walk", 0.2f);
                }
            }
            else
            {
                m_simpleAnimation.CrossFade("Default", 0.2f);
            }

        }
        else
        {
            if (!m_simpleAnimation.isPlaying)   //アニメーションの再生が終わったなら
            {
                m_isPlayingAnimation = false;   //フラグfalseに戻す
            }
        }
    
       


        //移動用変数を0に戻す
        m_forward = 0f;
        m_back = 0f;
        m_left = 0f;
        m_right = 0f;
        m_up = 0f;
        m_down = 0f;
    }

    public float Forward
    {
        set
        {
            m_forward = value;
        }
    }
    public float Back
    {
        set
        {
            m_back = value;
        }
    }
    public float Left
    {
        set
        {
            m_left = value;
        }
    }
    public float Right
    {
        set
        {
            m_right = value;
        }
    }
    public float Up
    {
        set
        {
            m_up = value;
        }
    }
    public float Down
    {
        set
        {
            m_down = value;
        }
    }



    /// <summary>
    /// アニメーションを再生する
    /// </summary>
    /// <param name="value"></param>
    /// <param name="callbackMethod"></param>
    public void PlayAnimation(string value, UnityAction callbackMethod)
    {
        m_unityEvent.AddListener(callbackMethod);   //コールバック関数の登録

        m_simpleAnimation.CrossFade(value, 0.2f);

        m_isPlayingAnimation = true;
    }

    /// <summary>
    /// アニメーション終了時のイベントを受け取る
    /// </summary>
    public void OnAnimationFinished()
    {
        m_unityEvent.Invoke();      //登録されているコールバック関数の呼び出し

        m_unityEvent.RemoveAllListeners();  //登録されていた関数を削除

        m_isPlayingAnimation = false;   //フラグをfalseに戻す
    }


    /// <summary>
    /// 当たり判定開始
    /// </summary>
    public void StartAttack()
    {
        m_SwordAttackcollider.enabled = true;
    }


    /// <summary>
    /// 
    /// </summary>
    public void EndAttack()
    {
        m_SwordAttackcollider.enabled = false;
    }


    /// <summary>
    /// ダメージ判定
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Attack")
        {
            m_rigitBody.AddForce(transform.forward * -5f, ForceMode.VelocityChange);
        }
    }
}
