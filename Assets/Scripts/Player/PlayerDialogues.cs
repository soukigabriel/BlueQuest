using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogues : MonoBehaviour
{
    public Dialogue initialDialogue;

    [ContextMenu("Trigger initial dialogue")]
    public void TriggerInitialDialogue()
    {
        if(!GameManager.sharedInstance.initialCinematicTriggered)
        {
            GameManager.sharedInstance.initialCinematicTriggered = true;
            DialogueManager.sharedInstance.StartDialogue(initialDialogue);
        }
    }
}
