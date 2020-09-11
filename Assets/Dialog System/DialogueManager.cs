using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	public Player player;
	public CameraControl cameraControl;

    //private Player player;
	private Queue<string> sentences;
	private Queue<GameObject> focusTargets;

	private Dialogue currentDialogue;

	public bool finished;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
		focusTargets = new Queue<GameObject>();

		currentDialogue = null;
		finished = false;
    }
	
	public void StartDialogue(Dialogue dialogue){
		animator.SetBool("IsOpen", true);
		finished = false;
		currentDialogue = dialogue;

		nameText.text = dialogue.name;

		if (dialogue.color == Color.RED)
			nameText.color = new UnityEngine.Color(140, 0, 0);

		else if (dialogue.color == Color.ORANGE)
			nameText.color = new UnityEngine.Color(255, 185, 0);

		else if (dialogue.color == Color.YELLOW)
			nameText.color = UnityEngine.Color.yellow;

		else if (dialogue.color == Color.SKYBLUE)
			nameText.color = new UnityEngine.Color(99, 197, 207);

		else if (dialogue.color == Color.SEABLUE)
			nameText.color = UnityEngine.Color.blue;

		else if (dialogue.color == Color.PURPLE)
			nameText.color = new UnityEngine.Color(169, 241, 0);

		else
			nameText.color = UnityEngine.Color.white;

		sentences.Clear();

		foreach (SentenceElement sentenceElement in dialogue.sentenceElements){
			sentences.Enqueue(sentenceElement.sentence);
			focusTargets.Enqueue(sentenceElement.focusAt);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence() {
		//player.BlockMovement();
		finished = false;
		if(sentences.Count == 0){
            if (currentDialogue.nextDialog != null)
            {
				Debug.Log("Displaying next dialog participant");
				currentDialogue.nextDialog.TriggerDialogue();
				return;
			}
			Debug.Log("Ending the dialog");
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		GameObject focusTarget = focusTargets.Dequeue();

		cameraControl.UpdateFollowTarget(focusTarget.transform);

		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		finished = false;
	}

	IEnumerator TypeSentence (string sentence) {
		finished = false;
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()){
			dialogueText.text += letter;
			yield return null;
		}
		finished = false;
	}

	public void EndDialogue() {
		animator.SetBool("IsOpen", false);
		player.FocusOnActiveBlob();
		finished = true;
	}
}
