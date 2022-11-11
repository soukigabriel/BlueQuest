using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public static Fade sharedInstance;

    [SerializeField]
    Image squareImage;
    [SerializeField] float fadeTime;
    [SerializeField] Ease ease;
    public PlayerDialogues playerDialogue;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    [ContextMenu("FadeIn")]
    public void FadeIn()
    {
        squareImage.enabled = true;
        squareImage.DOFade(1, fadeTime).SetEase(ease);
    }
    [ContextMenu("FadeOut")]
    public void FadeOut()
    {
        squareImage.DOFade(0, fadeTime).SetEase(ease).OnComplete(() => { squareImage.enabled = false; } );
    }

    public void InitialFadeIn()
    {
        squareImage.enabled = true;
        squareImage.DOFade(1, fadeTime).SetEase(ease).OnComplete(() => InitialFadeInEnd());
    }

    public void InitialFadeInEnd()
    {
        UIManager.sharedInstance.StartGame();
        InitialFadeOut();
    }

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
