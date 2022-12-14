using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets sharedInstance;
    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    public Sprite basicHelmetSprite;
    public Sprite strongHelmetSprite;
    public Sprite basicArmorSprite;
    public Sprite strongArmorSprite;
    public Sprite basicSwordSprite;
    public Sprite strongSwordSprite;
}
