using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;

    private Animator anim;
    
    public float moveTime = 0.1f;

    public LayerMask obstacle;

    private Rigidbody2D rgb2D;
    private BoxCollider2D boxColl;
    private Transform target;
    private HealthManager targetHealth;


    private float attackSpeed = 1.0f;
    private float inverseMoveTime;
    private float nextAttack = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rgb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        inverseMoveTime = 1f / moveTime;

        anim = GetComponent<Animator>();
    }

    protected void moveTo(Vector3 dest)
    {
        //float remainingDistance = (transform.position - dest).sqrMagnitude;

        Vector3 newPosition = Vector3.MoveTowards(rgb2D.position, new Vector3(dest.x, rgb2D.position.y), inverseMoveTime * Time.deltaTime);
        rgb2D.MovePosition(newPosition);
        
        //remainingDistance = (transform.position - dest).sqrMagnitude;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        HealthManager targetHealth = collision.gameObject.GetComponent<GeneralHealth>();

        if(collision.gameObject.tag == "Player" && targetHealth != null)
        {
            //collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            //Debug.Log(attackInterval);

            if(Time.time > nextAttack)
            {
                nextAttack = Time.time + attackSpeed;
                targetHealth.TakeDamage(damage);
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            moveTo(target.position);
            anim.SetBool("FoundPlayer", true); // need new OnTriggerExit

            anim.SetFloat("Speed", 1f); // this is so awkward lol. errors too. but implementation is weird o.o
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            anim.SetBool("FoundPlayer", false);
        }
    }

}
