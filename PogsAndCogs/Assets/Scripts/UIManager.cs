using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This needs to be a singleton
*/

public class UIManager : MonoBehaviour
{
    public Animator pauseAnim;
    public AnimationClip pauseEntryClip;
    public GameObject soundManager;
    private bool isMuted = false;
    public Text muteText;

    bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
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
        
        // check pause
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused == false) {
                // Pause
                PauseGame();
            } else {
                // Unpause
                UnpauseGame();
            }
        }
    }

    void PauseGame () {
        isPaused = true;

        // bring menu in
        pauseAnim.SetBool("PauseGame", true);

        // freeze
        StartCoroutine(FreezeGame(pauseAnim.GetCurrentAnimatorStateInfo(0).length - 0.7f)); // this needs to be better

        // handle options - i think this can be done in inspector. maybe implement funcs here
    }

    public void UnpauseGame () {
        isPaused = false;

        // bring menu out
        pauseAnim.SetBool("PauseGame", false);

        // unfreeze
        Time.timeScale = 1f;
    }
    
    IEnumerator FreezeGame (float delay = 0) {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0;   
    }

    public void ToggleMute () {
        if (isMuted) {
            isMuted = false;

            // change text
            muteText.text = "Mute: Off";

            // set volume to 0
            soundManager.GetComponent<AudioSource>().volume = 1;

        } else {
            isMuted = true;

            // change text
            muteText.text = "Mute: On";

            // set volume to 0
            soundManager.GetComponent<AudioSource>().volume = 0;    
        }
    }

    public void DisplayControls () {
        // change UI
        // this is extra stuff that not need til later
    }

    public void QuitGame () {
        Debug.Log("Game quit.");
    }
}
