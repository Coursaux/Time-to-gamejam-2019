using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ai : MonoBehaviour
{
    public float moveTime = 0.1f;

    public LayerMask obstacle;

    private Rigidbody2D rgb2D;
    private BoxCollider2D boxColl;

    private float inverseMoveTime;



    // Start is called before the first frame update
    void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rgb2D = GetComponent<Rigidbody2D>();

        inverseMoveTime = 1f / moveTime;
    }

    protected void moveTo(Vector3 dest)
    {
        float remainingDistance = (transform.position - dest).sqrMagnitude;

        Vector3 newPosition = Vector3.MoveTowards(rgb2D.position, dest, inverseMoveTime * Time.deltaTime);
        rgb2D.MovePosition(newPosition);
        remainingDistance = (transform.position - dest).sqrMagnitude;
    }

    protected abstract void onCantMove<T>(T component)
        where T : Component;

}
