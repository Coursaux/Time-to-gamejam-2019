using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthManager
{
    private AudioManager sound;
    private AudioSource source;
    private void Start()
    {
        sound = GetComponent<AudioManager>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.die();
    }

    protected override void die()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("we in");
            sound.dyingSound();
            Destroy(gameObject.GetComponent<PlayerController>());
            if(source.isPlaying == false)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
