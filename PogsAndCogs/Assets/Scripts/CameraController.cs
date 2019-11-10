using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float cameraForwardOffset;
    public Transform player;
    public float FollowSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset;
        PlayerController pc = player.gameObject.GetComponent<PlayerController>();
        if (pc.moveVelocity != 0) {
            offset = (pc.GetDirMult()) * cameraForwardOffset;
        } else {
            offset = (pc.GetDirMult()) * cameraForwardOffset * 0.5f;
        }

        Vector3 newPosition = new Vector3(player.position.x + offset, player.position.y, -10);
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
