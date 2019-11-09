using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseAi : MovableObject
{
    public int damage;

    private Transform target;
    private bool skipMove;

    // Start is called before the first frame update
    protected override void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void AttemptMove<T>(int xDirect, int yDirect)
    {
        if (skipMove)
        {
            skipMove = false;
            return;
        }
        base.AttemptMove<T>(xDirect, yDirect);

        skipMove = true;
    }

    public void MoveEnemy()
    {
        int xDirect = 0;
        int yDirect = 0;

        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
            yDirect = target.position.y > transform.position.y ? 1 : -1;
        else
            xDirect = target.position.x > transform.position.x ? 1 : -1;

        AttemptMove<PlayerController>(xDirect, yDirect);
    }

    protected override void onCantMove<T>(T component)
    {
        HealthManager hitPlayer = component as HealthManager;

        hitPlayer.currentHealth -= damage;

        throw new System.NotImplementedException();
    }
}
