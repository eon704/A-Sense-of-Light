using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public GameObject closedPortal;
    public GameObject openPortal;
    public bool foundKey;

    public DialogueManager dialogueManager;
    public DialogueTriger levelStartDialog;
    public DialogueTriger keyFoundDialog;
    public DialogueTriger levelCompleteDialog;
    public float dialogDelay;
    public float exitDelay;

    bool endLevel = false;

    private void Start()
    {
        foundKey = false;
        endLevel = false;

        StartCoroutine(BeginDialog(levelStartDialog));
    }

    private void Update()
    {
        if (endLevel)
        {
            Debug.Log("Ending level");
            if (dialogueManager.finished)
            {
                StartCoroutine(EndLevel());
            }
        } else
        {
            dialogueManager.finished = false;
        }
    }

    IEnumerator BeginDialog(DialogueTriger dialog)
    {
        yield return new WaitForSeconds(dialogDelay);
        dialog.TriggerDialogue();
    }

    public void FoundKey()
    {
        foundKey = true;
        StartCoroutine(BeginDialog(keyFoundDialog));
    }

    public void TryToOpenPortal()
    {
        if (foundKey)
        {
            LevelComplete();
        } else
        {
            Debug.Log("No Key...");
        }
    }

    public void LevelComplete()
    {
        Debug.Log("Win");
        closedPortal.SetActive(false);
        openPortal.SetActive(true);
        StartCoroutine(BeginDialog(levelCompleteDialog));
        endLevel = true;
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(exitDelay);
        LevelManager.LoadLevel("Levels");
    }

}
