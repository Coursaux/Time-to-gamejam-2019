using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioManager : MonoBehaviour
{

    private AudioSource source;
    public AudioClip attackSound;
    public AudioClip grassWalk;
    public AudioClip woodWalk;
    public AudioClip dieSound;

    private PlayerController player;
    private Rigidbody2D rgb2D;
    private Transform orientation;
    private HealthManager health;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        player = GetComponent<PlayerController>();
        rgb2D = GetComponent<Rigidbody2D>();
        orientation = GetComponent<Transform>();
        health = GetComponent<HealthManager>();
    }

    protected virtual void atkSound()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            source.SetScheduledStartTime(1);
            source.PlayOneShot(attackSound, 1.0f);
            source.SetScheduledStartTime(0);
        }
    }

    public void dyingSound()
    {
        if(health.currentHealth <= 0)
        {
            source.PlayOneShot(dieSound, 1.0f);
        }
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass" && rgb2D.velocity.x > 1f * orientation.localScale.z && source.isPlaying == false)
        {
            source.PlayOneShot(grassWalk, 1.0f);
        }
        else if (collision.gameObject.tag == "Wood" && rgb2D.velocity.x > 1f * orientation.localScale.z && source.isPlaying == false)
        {
            source.PlayOneShot(woodWalk, 1.0f);
        }
    }
}
