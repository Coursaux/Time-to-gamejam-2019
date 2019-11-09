using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNPC : MonoBehaviour, IClickable
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;


    public int Activate () 
    {
        dialogueManager.StartDialogue(dialogue);

        // freeze movement??

        return 0;
    }
}
