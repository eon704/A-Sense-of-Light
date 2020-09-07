using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{ 	
	public Text nameText;
	public Text dialogueText;

	public Animator animator;

    //private Player player;
	private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
	
	public void StartDialogue(Dialogue dialogue){
		animator.SetBool("IsOpen", true);

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

		foreach (string sentence in dialogue.sentences){
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence() {
		//player.BlockMovement();
		if(sentences.Count == 0){
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence) {
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()){
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue() {
		animator.SetBool("IsOpen", false);
	}
}
