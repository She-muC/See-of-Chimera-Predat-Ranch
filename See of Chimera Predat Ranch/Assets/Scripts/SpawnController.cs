using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject shroomPrefab;
    public GameObject shroom2Prefab;
    public GameObject bombPrefab;


    public float SpawnTime;
    private float SetTime;
    private int Rare;
    private int Enemykind;

    bool isSpawnFinish = true;

	// Use this for initialization
	IEnumerator Start ()
    {
        SetTime = SpawnTime;

        Rare = Random.Range(0, 4 + 1);
        Debug.Log(Rare);
        while(true)
        {
            Enemykind = Random.Range(0, 1 + 1);
            switch (Enemykind)
            {
                case 0: GameObject Shroom1 = Instantiate(shroomPrefab) as GameObject;
                        Shroom1.transform.position = new Vector3(Random.Range(115, 233), 1f, Random.Range(65, 140));
                break;

                case 1:
                        GameObject Shroom2 = Instantiate(shroom2Prefab) as GameObject;
                        Shroom2.transform.position = new Vector3(Random.Range(115, 233), 1f, Random.Range(65, 140));
                break;

            }
            Debug.Log(Enemykind);

            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        SpawnTime -= Time.deltaTime;
        
        if (Rare != 0 && SpawnTime < 0)
        {          
            Debug.Log("スポーン！");

            GameObject Bomb = Instantiate(bombPrefab) as GameObject;
            Bomb.transform.position = new Vector3(Random.Range(115, 233), 1f, Random.Range(65, 140));
            SpawnTime = SetTime;
            Rare--;
        }
    }
        
	
}
