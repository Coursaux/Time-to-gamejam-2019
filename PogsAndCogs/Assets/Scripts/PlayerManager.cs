using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject wrenchHit;
    public float attackSpeed = 0.5f;
    private float lastAttack = -10f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && lastAttack + attackSpeed < Time.time)
        {
            animator.SetTrigger("Attack");
            lastAttack = Time.time;
            GameObject wrench = Instantiate(wrenchHit, transform.position, transform.rotation);
            wrench.transform.SetParent(this.gameObject.transform);
        }
    }
}
