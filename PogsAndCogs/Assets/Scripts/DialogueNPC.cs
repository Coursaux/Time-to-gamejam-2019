using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour, IClickable
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    void Update () {
        // check click
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Clickable"));

            if (hit.collider != null) {
                IClickable clickable = hit.collider.gameObject.GetComponent<IClickable>();
                if (clickable != null) {
                    clickable.Activate();
                }
            }
        }
    }


    public int Activate () 
    {
        dialogueManager.StartDialogue(dialogue);

        // freeze movement??

        return 0;
    }
}
