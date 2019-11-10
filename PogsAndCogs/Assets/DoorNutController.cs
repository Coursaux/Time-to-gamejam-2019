using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorNutController : MonoBehaviour
{
    public TutorialRock[] rocks;


    // Update is called once per frame
    void Update()
    {
        bool allDead = true;
        foreach (TutorialRock r in rocks) {
            if (r.isDead != true) {
                allDead = false;
                break;
            }
        }

        if (allDead) {
            Debug.Log("This door is now open");
            SceneManager.LoadScene("OrionTowerInterior");
        }
    }
}
