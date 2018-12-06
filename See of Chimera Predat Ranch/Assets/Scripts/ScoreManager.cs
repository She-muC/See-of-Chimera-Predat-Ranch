using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text animalScore;
	
	// Update is called once per frame
	void Update ()
    {
        animalScore.text = "animal1:" + AnimalCotroller.animalpoint[0] + '\n' + "animal2:" + AnimalCotroller.animalpoint[1] + '\n' + "animal3:" + AnimalCotroller.animalpoint[2];
    }
}
