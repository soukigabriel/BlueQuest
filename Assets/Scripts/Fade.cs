using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public static Fade sharedInstance;

    [Tooltip("Image of the Fade")]
    [SerializeField] Image squareImage;
    [Tooltip("Time that the fade will take")]
    [SerializeField] float fadeTime;
    [Tooltip("Ease of the fade")]
    [SerializeField] Ease ease;
    [Tooltip("Reference to the PlayerDialogue")]
    public PlayerDialogues playerDialogue;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    //Normal fade in
    public void FadeIn()
    {
        squareImage.enabled = true;
        squareImage.DOFade(1, fadeTime).SetEase(ease);
    }
    
    //Normal fade out
    public void FadeOut()
    {
        squareImage.DOFade(0, fadeTime).SetEase(ease).OnComplete(() => { squareImage.enabled = false; } );
    }

    //Fade in for the initial cinematic
    public void InitialFadeIn()
    {
        squareImage.enabled = true;
        squareImage.DOFade(1, fadeTime).SetEase(ease).OnComplete(() => InitialFadeInEnd());
    }

    //Methods that will be called at the end of the initial fade in
    public void InitialFadeInEnd()
    {
        UIManager.sharedInstance.StartGame();
        InitialFadeOut();
    }

    //Fade out of the initial cinematic
    public void InitialFadeOut()
    {
        if(GameManager.sharedInstance.initialCinematicTriggered)
        {
            FadeOut();
            return;
        }
        squareImage.DOFade(0, fadeTime).SetEase(ease).OnComplete(() => { playerDialogue.TriggerInitialDialogue(); squareImage.enabled = false; } );
    }

    private void Start()
    {
        FadeOut();
    }
}
