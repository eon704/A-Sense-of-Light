using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
	public string name;
    public Color color;
    
    public DialogueTriger nextDialog;
    public SentenceElement[] sentenceElements;
}

[System.Serializable]
public class SentenceElement
{
    [TextArea(3,10)]
    public string sentence;
    public GameObject focusAt;
}