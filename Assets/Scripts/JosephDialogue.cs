using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JosephDialogue : MonoBehaviour
{
    public Dialogue firstMetDialogue;
    public Dialogue secondDialogue;
    public Dialogue thirdDialogue;
    public Dialogue finalDialogue;
    public CircleCollider2D m_CircleCollider;
    Queue<Dialogue> dialogueQueue;

    private void Start()
    {
        dialogueQueue = new Queue<Dialogue>();
        UIManager.sharedInstance.dialogueButton.GetComponent<Button>().onClick.AddListener(TriggerButtonDialogue);
        dialogueQueue.Enqueue(secondDialogue);
        dialogueQueue.Enqueue(thirdDialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (DialogueManager.sharedInstance.firstJosephDialogueTriggered)
                return;
            TriggerColliderDialogue(firstMetDialogue);
            DialogueManager.sharedInstance.firstJosephDialogueTriggered = true;
        }
    }

    public void TriggerButtonDialogue()
    {
        if(DialogueManager.sharedInstance.firstJosephDialogueTriggered)
        {
            if(dialogueQueue.Count == 0)
            {
                DialogueManager.sharedInstance.StartDialogue(finalDialogue);
                return;
            }
            Dialogue currentDialogue = dialogueQueue.Dequeue();
            DialogueManager.sharedInstance.StartDialogue(currentDialogue);
        }
    }

    public void TriggerColliderDialogue(Dialogue dialogue)
    {
        DialogueManager.sharedInstance.StartDialogue(dialogue);
    }
}
