using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script moves platforms between points that are needed to be set up
    TO SET UP:
        1. On inspector, increase size of checkpoints to n, where n is the number of desired checkpoints
        2. Create n empty objects as child of platform, and place where desired
        3. From heirarchy, drag each checkpoint into script on the inspector
        *Note - order does matter
*/
public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 3;

    public List<Transform> checkpoints;
    private int targ = 1;

    void Start () 
    {
        transform.position = checkpoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // move here
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, checkpoints[targ].position, step);

        // update target
        if (Vector3.Distance(transform.position, checkpoints[targ].position) < 0.1f) {
            targ = (targ == checkpoints.Count - 1 ? 0 : targ + 1);
        }
    }
}
