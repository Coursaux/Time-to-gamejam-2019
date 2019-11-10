using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    https://www.youtube.com/watch?v=3UO-1suMbNc
*/

public class backgroundLoop : MonoBehaviour{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke;
    public float scrollSpeed;

    void Start(){
        // object to follow
        //mainCamera = gameObject.GetComponent<Camera>();
        mainCamera = Camera.main;
        Debug.Log(mainCamera.ToString());

        // what camera sees
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        // for each defined "thing" on levels, instantiate and position
        foreach(GameObject obj in levels){
            loadChildObjects(obj);
        }
    }

    // instantiate each element of background
    void loadChildObjects(GameObject obj){
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childsNeeded; i++){
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    // Update position of each level
    void repositionChildObjects(GameObject obj){
        Transform[] children = obj.GetComponentsInChildren<Transform>(); // grab all children
        if(children.Length > 1){
            GameObject firstChild = children[1].gameObject; // first??? index 0????
            GameObject lastChild = children[children.Length - 1].gameObject;

            // get width: for calculating offsets
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;

            // switch positions of children
            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth){ // case right rotate
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            } else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth){ // case left rotate
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void Update() {

        Vector3 velocity = Vector3.zero; // new here : desired velocity???
        Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0); // position based off of given scroll speed. slow for parallax??
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f); // slowly change position
        transform.position = smoothPosition; // change position here

    }

    
    void LateUpdate(){
        foreach(GameObject obj in levels) {
            repositionChildObjects(obj);
        }
    }
}