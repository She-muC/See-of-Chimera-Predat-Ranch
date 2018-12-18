using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {
	
	[SerializeField]
	GameObject[]	m_characterPrefabs;

    public CameraController Camera1;
    public CameraController Camera2;
    public CameraController Camera3;
    public CameraController Camera4;


    Vector3 m_1PPosition;

	Vector3 m_2PPosition;

	Vector3 m_3PPosition;

	Vector3 m_4PPosition;
	// Use this for initialization
	void Start ()
    {
        

		//キャラ選択画面で保存した値の読み込み
		int selectNo1P = PlayerPrefs.GetInt ("1P", 0);
		int selectNo2P = PlayerPrefs.GetInt ("2P", 0);
		int selectNo3P = PlayerPrefs.GetInt ("3P", 0);
		int selectNo4P = PlayerPrefs.GetInt ("4P", 0);

		m_1PPosition = new Vector3(Random.Range(115, 233), 1f, Random.Range(65, 140));
		m_2PPosition = new Vector3(Random.Range(115, 233), 1f, Random.Range(65, 140));
		m_3PPosition = new Vector3(Random.Range(115, 233), 1f, Random.Range(65, 140));
		m_4PPosition = new Vector3(Random.Range(115, 233), 1f, Random.Range(65, 140));

		// 1Pキャラの読み込み--------------------------------
		GameObject player1 = Instantiate (m_characterPrefabs [selectNo1P],m_1PPosition,Quaternion.identity);
		GameObject player2 = Instantiate (m_characterPrefabs [selectNo2P],m_2PPosition,Quaternion.identity);
		GameObject player3 = Instantiate (m_characterPrefabs [selectNo3P],m_3PPosition,Quaternion.identity);
		GameObject player4 = Instantiate (m_characterPrefabs [selectNo4P],m_4PPosition,Quaternion.identity);

        Camera1.m_target = player1.transform.Find("LookAt").gameObject;
        Camera2.m_target = player2.transform.Find("LookAt").gameObject;
        Camera3.m_target = player3.transform.Find("LookAt").gameObject;
        Camera4.m_target = player4.transform.Find("LookAt").gameObject;

        player1.transform .Rotate(new Vector3(0,Random.Range(0,359),0));
		player2.transform .Rotate(new Vector3(0,Random.Range(0,359),0));
		player3.transform .Rotate(new Vector3(0,Random.Range(0,359),0));
		player4.transform .Rotate(new Vector3(0,Random.Range(0,359),0));

        player1.name = "Player1";
        player2.name = "Player2";
        player3.name = "Player3";
        player4.name = "Player4";

        Debug.Log("1P" + m_1PPosition);
        Debug.Log("2P" + m_2PPosition);
        Debug.Log("3P" + m_3PPosition);
        Debug.Log("4P" + m_4PPosition);

    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
