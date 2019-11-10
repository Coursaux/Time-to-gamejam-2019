using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject camera;
    public float rotationSpeed = 2;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, 1);
        transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }
}
