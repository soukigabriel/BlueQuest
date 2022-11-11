using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogues : MonoBehaviour
{
    [Tooltip("Dialogue of the initial cinematic")]
    public Dialogue initialDialogue;

    public void TriggerInitialDialogue()
    {
        if(!GameManager.sharedInstance.initialCinematicTriggered)
        {
            GameManager.sharedInstance.initialCinematicTriggered = true;
            DialogueManager.sharedInstance.StartDialogue(initialDialogue);
        }
    }
}
