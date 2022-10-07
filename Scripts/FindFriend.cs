using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class FindFriend : MonoBehaviour
{
    public GameObject Dialoguepanel;
    private Queue<string> sentences;
    public Text dialogueTxt;

    public GameObject missionCompletemenu;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void SkipDialogue()
    {
        EndDialogue();
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueTxt.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTxt.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        StartCoroutine(waitforseconds());
    }

    IEnumerator waitforseconds()
    {
        yield return new WaitForSeconds(1);
        Dialoguepanel.SetActive(false);
        missionCompletemenu.SetActive(true);
    }
}