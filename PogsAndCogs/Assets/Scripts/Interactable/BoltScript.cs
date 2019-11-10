using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : HealthManager
{
    private HealthManager health;
    public float decreaseRate = 0.25f;

    private Transform boltPosition;


    // Start is called before the first frame update
    void Start()
    {
        boltPosition = GetComponent<Transform>();
        //health = GetComponent<HealthManager>();
        Debug.Log(boltPosition.position);
        
    }

    private void Update()
    {
        die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wrench")
        {
            Debug.Log("in");
            boltPosition.Translate(Vector3.down * decreaseRate);
            Debug.Log(boltPosition.position);

        }
    }

    protected override void die()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }

}
