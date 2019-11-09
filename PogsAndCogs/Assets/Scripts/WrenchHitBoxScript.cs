using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchHitBoxScript : MonoBehaviour
{
    public float lifeTime = 0.2f;
    private float spawnTime;

    private int atkDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime + lifeTime < Time.time)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        HealthManager hm = col.gameObject.GetComponent<HealthManager>();
        if(hm != null)
        {
            hm.TakeDamage(atkDamage);
        }
    }
}
