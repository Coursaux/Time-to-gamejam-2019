using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=_nRzoTzeyxU

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator anim;

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();   
    }

    public void StartDialogue (Dialogue dialogue) 
    {
        anim.SetBool("DialogueOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string s in dialogue.sentences) {
            sentences.Enqueue(s);
        }

        DisplayNextSentence();
    }

    private void DisplayNextSentence () {
        // case if queue empty
        if (sentences.Count == 0) {
            EndDialogue();
            Debug.Log("sentences empty");
            return;
        }

        // else
        string s = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(s));
    }

    private IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char c in sentence.ToCharArray()) {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.06f);
        }
    }

    public void EndDialogue () {
        anim.SetBool("DialogueOpen", false);
    }
}
