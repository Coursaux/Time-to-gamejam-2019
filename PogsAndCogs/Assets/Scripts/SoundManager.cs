using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This needs to be a singleton
*/

public class SoundManager : MonoBehaviour
{
    GameObject playerRef;

    AudioSource audioSource;

    public AudioClip[] clips;

    void Start () {
        playerRef = GameObject.FindGameObjectWithTag("Player"); // assumes there is only one player at one time
        audioSource = GetComponent<AudioSource>();
        if (clips.Length > 0) {
            audioSource.clip = clips[0];        
        }
        audioSource.Play();
    }

    void Update () {
        Vector3 newPosition = playerRef.transform.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, 3f * Time.deltaTime);
    }
}
