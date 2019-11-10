using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthManager
{
    private AudioManager sound;
    private AudioSource source;
    //private bool first = true;
    private void Start()
    {
        sound = GetComponent<AudioManager>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        die();
    }

    protected override void die()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("we in");
            //if (first)
            //{
               // sound.dyingSound();
              //  first = false;
            //}
            
            Destroy(gameObject.GetComponent<PlayerController>());
            if(source.isPlaying == false)
            {
                gameObject.SetActive(false);
                Scene currScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currScene.name);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
