using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObject : MonoBehaviour
{
    public float moveTime = 0.1f;

    public LayerMask blockingLayer;

    private BoxCollider2D boxCol;
    private Rigidbody2D rgb2D;

    private float inverseMoveTime;

    // Start is called before the first frame update
    protected virtual void Start()
    {

        boxCol = GetComponent<BoxCollider2D>();
        rgb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;

    }
    
    protected bool Move(int xDirect, int yDirect, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDirect, yDirect);

        boxCol.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCol.enabled = true;

        if(hit.transform == null)
        {
            StartCoroutine(Movement(end));
            return true;
        }

        return false;
    }

    protected IEnumerator Movement(Vector3 end)
    {
        float remainingDistance = (transform.position - end).sqrMagnitude;

        while(remainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(rgb2D.position, end, inverseMoveTime * Time.deltaTime);
            rgb2D.MovePosition(newPosition);
            remainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }

    protected virtual void AttemptMove<T>(int xDirect, int yDirect)
        where T : Component
    {
        RaycastHit2D hit;

        bool canMove = Move(xDirect, yDirect, out hit);

        if(hit.transform == null)
        {
            return;
        }

        T hitComponent = hit.transform.GetComponent<T>();

        if(!canMove && hitComponent != null)
        {
            onCantMove(hitComponent);
        }
    }

    protected abstract void onCantMove<T>(T component)
        where T : Component;
    
}
