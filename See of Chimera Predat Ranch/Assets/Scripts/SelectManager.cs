using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events ;
public class SelectManager : MonoBehaviour
{
	[SerializeField]
	GameObject[]	m_characterPrefabs;	// キャラクターのプレハブ群
	GameObject[]	m_charater = new GameObject[4];	// インスタンス化したキャラを保持する変数
	int       []	m_loadedCharacter = new int[4];	// ロードしたキャラの番号
	bool      []	m_selectFinished = new bool[4];	// 選択が完了したか

	[SerializeField]
	Vector3			m_1PPosition;		// 1Pキャラクター表示位置

	[SerializeField]
	Vector3			m_2PPosition;		// 2Pキャラクター表示位置

	[SerializeField]
	Vector3			m_3PPosition;		// 3Pキャラクター表示位置

	[SerializeField]
	Vector3			m_4PPosition;		// 4Pキャラクター表示位置

	[SerializeField]
	RectTransform   m_1PCursor;			// 1Pカーソル

	[SerializeField]
    RectTransform   m_2PCursor;			// 2Pカーソル

	[SerializeField]
    RectTransform   m_3PCursor;			// 3Pカーソル

	[SerializeField]
    RectTransform   m_4PCursor;			// 4Pカーソル


	[SerializeField]
	Text			m_startText;		// スタート用テキスト

	[SerializeField]
	int				m_characterNum;		// キャラの数

	[SerializeField]
	float			m_cursorDistance;	// カーソルの移動量

	int				m_1PSelect;			// 1Pが選択しているキャラ番号
	int				m_2PSelect;			// 2Pが選択しているキャラ番号
	int				m_3PSelect;			// 3Pが選択しているキャラ番号
	int				m_4PSelect;			// 4Pが選択しているキャラ番号

	Vector3			m_1PCursorDefaultPosition;	// 1Pカーソルのデフォルト位置
	Vector3			m_2PCursorDefaultPosition;	// 2Pカーソルのデフォルト位置
	Vector3			m_3PCursorDefaultPosition;	// 3Pカーソルのデフォルト位置
	Vector3			m_4PCursorDefaultPosition;	// 4Pカーソルのデフォルト位置

	enum State
	{
		Doing,
		Selected,
	}
	State m_state = State.Doing;


	// Use this for initialization
	void Start ()
    {
		// 1Pと2Pのカーソル初期位置を記録
		m_1PCursorDefaultPosition = m_1PCursor.anchoredPosition;
		m_2PCursorDefaultPosition = m_2PCursor.anchoredPosition;
		m_3PCursorDefaultPosition = m_3PCursor.anchoredPosition;
		m_4PCursorDefaultPosition = m_4PCursor.anchoredPosition;


		// 2Pカーソルの位置を初期化
		m_2PSelect = 1;
		m_2PCursor.anchoredPosition = m_2PCursorDefaultPosition + 
		new Vector3(m_2PSelect * m_cursorDistance,0,0);



		// 3Pカーソルの位置を初期化
		m_3PSelect = 2;
		m_3PCursor.anchoredPosition = m_3PCursorDefaultPosition + 
		new Vector3(m_3PSelect * m_cursorDistance,0,0);


		// 4Pカーソルの位置を初期化
		m_4PSelect = 3;
		m_4PCursor.anchoredPosition = m_4PCursorDefaultPosition + 
		new Vector3(m_4PSelect * m_cursorDistance,0,0);

		// スタート用テキストを非表示
		m_startText.enabled = false;

		// ロードしたキャラの番号を初期化
		m_loadedCharacter [0] = -1;
		m_loadedCharacter [1] = -1;
		m_loadedCharacter [2] = -1;
		m_loadedCharacter [3] = -1;
	}

	// Update is called once per frame
	void Update ()
    {
		if (m_state == State.Selected)
        {
			return;
		}

		// 1P2Pとも選択されている状態
		if (m_selectFinished [0] && m_selectFinished [1] && m_selectFinished [2] && m_selectFinished [3])
        {
			// 1Pか2Pが決定キーを押した
			if (Input.GetKeyDown (KeyCode.G)){
				// どのキャラを選択したかを記録
				PlayerPrefs.SetInt("1P", m_1PSelect);	// キーと値の組み合わせ
				PlayerPrefs.SetInt("2P", m_2PSelect);	// キーと値の組み合わせ
				PlayerPrefs.SetInt("3P", m_3PSelect);	// キーと値の組み合わせ
				PlayerPrefs.SetInt("4P", m_4PSelect);	// キーと値の組み合わせ
				PlayerPrefs.Save ();	// ストレージに書き込む

				//UnityAction callbackMethod = OntrnsitonFinished;

				//TransitonManager.Instance.Fade (new Color (0, 0, 0, 0), new Color (0, 0, 0, 1), 2f,
				//2callbackMethod);

				OntrnsitonFinished();
				m_state = State.Selected;
			
				return;
			}
		}

		if (!m_selectFinished [0])
        {
			// 1Pカーソル右移動
			if (Input.GetKeyDown (KeyCode.D)) {//A
				m_1PSelect++;
			}
			// 1Pカーソル左移動
			else if (Input.GetKeyDown (KeyCode.A)) {//D
				m_1PSelect--;
			}

			// キャラ決定
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				m_selectFinished [0] = true;
				if (m_selectFinished [0]&&m_selectFinished [1]&&m_selectFinished [2]&&m_selectFinished [3]) {		// スタートテキスト表示
					m_startText.enabled = true;
				}
				//PlayerController pc = m_charater [0].GetComponent<PlayerController> ();
				//pc.Target = Camera.main.gameObject;	// カメラの方を向く
			}
		}
		else
        {
			// キャラ決定解除
			if (Input.GetKeyDown (KeyCode.Alpha1))
            {
				m_selectFinished [0] = false;
				m_startText.enabled = false;	// スタートテキスト非表示
				//PlayerController pc = m_charater [0].GetComponent<PlayerController> ();
				//pc.Target = gameObject;	// 中央を向く
			}
		}
		// 上限下限チェック
		m_1PSelect = Mathf.Clamp(m_1PSelect, 0, m_characterNum - 1);
		m_1PCursor.anchoredPosition = m_1PCursorDefaultPosition + 
		new Vector3(m_1PSelect * m_cursorDistance,0,0);


		if (!m_selectFinished [1])
        {
			// 2Pカーソル右移動
			if (Input.GetKeyDown (KeyCode.RightArrow))
            {
				m_2PSelect++;
			}
			// 2Pカーソル左移動
			else if (Input.GetKeyDown (KeyCode.LeftArrow))
            {
				m_2PSelect--;
			}
			
            
            // キャラ決定
			if (Input.GetKeyDown (KeyCode.Alpha2))
            {
				m_selectFinished [1] = true;
				if (m_selectFinished [0]&&m_selectFinished [1]&&m_selectFinished [2]&&m_selectFinished [3])
                {		
					m_startText.enabled = true;
				}
				//PlayerController pc = m_charater [1].GetComponent<PlayerController> ();
				//pc.Target = Camera.main.gameObject;	// カメラの方を向く
			}
		}
		else
        {
			// キャラ決定解除
			if (Input.GetKeyDown (KeyCode.Alpha2))
            {
				m_selectFinished [1] = false;
				m_startText.enabled = false;
				//PlayerController pc = m_charater [1].GetComponent<PlayerController> ();
				//pc.Target = gameObject;	// 中央を向く
			}
		}
		// 上限下限チェック
		m_2PSelect = Mathf.Clamp(m_2PSelect, 0, m_characterNum - 1);
		m_2PCursor.anchoredPosition = m_2PCursorDefaultPosition + 
		new Vector3(m_2PSelect * m_cursorDistance,0,0);
		
		if (!m_selectFinished [2])
        {
			// 3Pカーソル右移動
			if (Input.GetKeyDown (KeyCode.Keypad3)) {//キーパッド1
				m_3PSelect++;
			}
			// 3Pカーソル左移動
			else if (Input.GetKeyDown (KeyCode.Keypad1)) {//キーパッド3
				m_3PSelect--;
			}
			// キャラ決定
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				m_selectFinished [2] = true;
				if (m_selectFinished [0]&&m_selectFinished [1]&&m_selectFinished [2]&&m_selectFinished [3]) {		// スタートテキスト表示
					m_startText.enabled = true;
				}
				//PlayerController pc = m_charater [1].GetComponent<PlayerController> ();
				//pc.Target = Camera.main.gameObject;	// カメラの方を向く
			}
		}
		else {
			// キャラ決定解除
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				m_selectFinished [2] = false;
				m_startText.enabled = false;
				//PlayerController pc = m_charater [1].GetComponent<PlayerController> ();
				//pc.Target = gameObject;	// 中央を向く
			}
		}

		// 上限下限チェック
		m_3PSelect = Mathf.Clamp(m_3PSelect, 0, m_characterNum - 1);
		m_3PCursor.anchoredPosition = m_3PCursorDefaultPosition + 
			new Vector3(m_3PSelect * m_cursorDistance,0,0);
		//4P
		if (!m_selectFinished [3]) {
			// 4Pカーソル右移動
			if (Input.GetKeyDown (KeyCode.L)) {
				m_4PSelect++;
			}
			// 4Pカーソル左移動
			else if (Input.GetKeyDown (KeyCode.J)) {
				m_4PSelect--;
			}
			// キャラ決定
			if (Input.GetKeyDown (KeyCode.Alpha4)) {
				m_selectFinished [3] = true;
				if (m_selectFinished [0]&&m_selectFinished [1]&&m_selectFinished [2]&&m_selectFinished [3]) {		// スタートテキスト表示
					m_startText.enabled = true;
				}
				//PlayerController pc = m_charater [1].GetComponent<PlayerController> ();
				//pc.Target = Camera.main.gameObject;	// カメラの方を向く
			}
		}
		else {
			// キャラ決定解除
			if (Input.GetKeyDown (KeyCode.Alpha4)) {
				m_selectFinished [3] = false;
				m_startText.enabled = false;
				//PlayerController pc = m_charater [1].GetComponent<PlayerController> ();
				//pc.Target = gameObject;	// 中央を向く
			}
		}
		// 上限下限チェック
		m_4PSelect = Mathf.Clamp(m_4PSelect, 0, m_characterNum - 1);
		m_4PCursor.anchoredPosition = m_4PCursorDefaultPosition + 
			new Vector3(m_4PSelect * m_cursorDistance,0,0);


		// キャラクターのロード
		if (m_loadedCharacter[0] != m_1PSelect) {	// 違うキャラなら読み込み
			m_loadedCharacter[0] = m_1PSelect;
			Destroy (m_charater [0]);	// 破棄
			m_charater [0] = Instantiate (m_characterPrefabs [m_1PSelect],
				m_1PPosition,
				Quaternion.Euler (Vector3.right));
			
			//m_charater [0].GetComponent<PlayerController> ().Target = gameObject;
		}
		if (m_loadedCharacter[1] != m_2PSelect) {	// 違うキャラなら読み込み
			m_loadedCharacter[1] = m_2PSelect;
			Destroy (m_charater [1]);	// 破棄
			m_charater [1] = Instantiate (m_characterPrefabs [m_2PSelect],
				m_2PPosition,
				Quaternion.Euler (Vector3.left));
			//m_charater [1].GetComponent<PlayerController> ().Target = gameObject;
		}
		if (m_loadedCharacter[2] != m_3PSelect) {	// 違うキャラなら読み込み
			m_loadedCharacter[2] = m_3PSelect;
			Destroy (m_charater [2]);	// 破棄
			m_charater [2] = Instantiate (m_characterPrefabs [m_3PSelect],
				m_3PPosition,
				Quaternion.Euler (Vector3.left));
			//m_charater [2].GetComponent<PlayerController> ().Target = gameObject;
		}
		if (m_loadedCharacter[3] != m_4PSelect) {	// 違うキャラなら読み込み
			m_loadedCharacter[3] = m_4PSelect;
			Destroy (m_charater [3]);	// 破棄
			m_charater [3] = Instantiate (m_characterPrefabs [m_4PSelect],
				m_4PPosition,
				Quaternion.Euler (Vector3.left));
        }




	}
	void OntrnsitonFinished(){
		//シーンの切り替え
		SceneManager.LoadScene("Farm");
	}
}
