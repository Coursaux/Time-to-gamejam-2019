using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonedWrench : MonoBehaviour
{
    public GameObject myChild;

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            myChild.SetActive(false);
        }
    }
}
