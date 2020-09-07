using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public GameObject closedPortal;
    public GameObject openPortal;
    public bool foundKey;

    public DialogueTriger levelStartDialog;
    public DialogueTriger keyFoundDialog;
    public DialogueTriger levelCompleteDialog;
    public float dialogDelay;


    private void Start()
    {
        foundKey = false;

        StartCoroutine(BeginDialog(levelStartDialog));
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
    }
}
