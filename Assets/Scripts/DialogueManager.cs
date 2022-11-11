using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;
    public static DialogueManager sharedInstance;

    public bool firstJosephDialogueTriggered;

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialogueBox;

    Coroutine typeSenteceRoutine;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        sentences = new Queue<string>();
        firstJosephDialogueTriggered = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        UIManager.sharedInstance.HideHUD();
        GameManager.sharedInstance.SetGameState(GameState.inDialogue);
        dialogueBox.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        if(typeSenteceRoutine != null)
        {
            StopCoroutine(typeSenteceRoutine);
        }
        typeSenteceRoutine = StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForFixedUpdate();
        }
    }

    void EndDialogue()
    {
        UIManager.sharedInstance.ShowHUD();
        dialogueBox.SetActive(false);
        GameManager.sharedInstance.SetGameState(GameState.inGame);
    }
}
