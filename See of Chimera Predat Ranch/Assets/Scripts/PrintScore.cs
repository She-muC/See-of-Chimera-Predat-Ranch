using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour
{
    public Text animalText;
    private string name;

    void Start ()
    {
        name = transform.tag;

        switch (name)
        {
            case "animal1":
            animalText.text = "animal1:" + AnimalCotroller.animalpoint[0].ToString();
            break;

            case "animal2":
            animalText.text = "animal2:" + AnimalCotroller.animalpoint[1].ToString();
            break;

            case "animal3":
            animalText.text = "animal3:" + AnimalCotroller.animalpoint[2].ToString();
            break;

        }

        Debug.Log("Result animal1:" + AnimalCotroller.animalpoint[0]);
        Debug.Log("Result animal2:" + AnimalCotroller.animalpoint[1]);
        Debug.Log("Result animal3:" + AnimalCotroller.animalpoint[2]);
    }
}
