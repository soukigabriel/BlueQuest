using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesChange : MonoBehaviour
{


    //Front character sprites
    public Sprite frontLeftArmClotheSprite;
    public Sprite frontRightArmClotheSprite;
    public Sprite frontLeftLegClotheSprite;
    public Sprite frontRightLegClotheSprite;

    public Sprite frontLeftArmNakedSprite;
    public Sprite frontRightArmNakedSprite;
    public Sprite frontLeftLegNakedSprite;
    public Sprite frontRightLegNakedSprite;

    //UI Character
    public SpriteRenderer InventoryFrontHat;
    public SpriteRenderer InventoryFrontBodyClothes;
    public SpriteRenderer InventoryFrontLeftArm;
    public SpriteRenderer InventoryFrontRightArm;
    public SpriteRenderer InventoryWeaponSprite;
    public SpriteRenderer InventoryFrontLeftLeg;
    public SpriteRenderer InventoryFrontRightLeg;

    //Front Character
    public SpriteRenderer frontHat;
    public SpriteRenderer frontBodyClothes;
    public SpriteRenderer frontLeftArm;
    public SpriteRenderer frontRightArm;
    public SpriteRenderer weaponSprite;
    public SpriteRenderer frontLeftLeg;
    public SpriteRenderer frontRightLeg;

    //Hat
    public void ShowHat()
    {
        frontHat.enabled = true;
        InventoryFrontHat.enabled = true;
    }
    public void HideHat()
    {
        frontHat.enabled = false;
        InventoryFrontHat.enabled = false;
    }
    public void ChangeHat(Sprite newSprite)
    {
        frontHat.sprite = newSprite;
        InventoryFrontHat.sprite = newSprite;
    }


    //Clothes
    public void ShowClothe()
    {
        //Show character clothe
        frontBodyClothes.enabled = true;
        frontLeftArm.sprite = frontLeftArmClotheSprite;
        frontRightArm.sprite = frontRightArmClotheSprite;
        frontLeftLeg.sprite = frontLeftLegClotheSprite;
        frontRightLeg.sprite = frontRightLegClotheSprite;

        //Show UI character clothe
        InventoryFrontBodyClothes.enabled = true;
        InventoryFrontLeftArm.sprite = frontLeftArmClotheSprite;
        InventoryFrontRightArm.sprite = frontRightArmClotheSprite;
        InventoryFrontLeftLeg.sprite = frontLeftLegClotheSprite;
        InventoryFrontRightLeg.sprite = frontRightLegClotheSprite;
    }
    public void HideClothe()
    {
        //Hide character clothe
        frontBodyClothes.enabled = false;
        frontLeftArm.sprite = frontLeftArmNakedSprite;
        frontRightArm.sprite = frontRightArmNakedSprite;
        frontLeftLeg.sprite = frontLeftLegNakedSprite;
        frontRightLeg.sprite = frontRightLegNakedSprite;

        //Hide UI character clothe
        InventoryFrontBodyClothes.enabled = false;
        InventoryFrontLeftArm.sprite = frontLeftArmNakedSprite;
        InventoryFrontRightArm.sprite = frontRightArmNakedSprite;
        InventoryFrontLeftLeg.sprite = frontLeftLegNakedSprite;
        InventoryFrontRightLeg.sprite = frontRightLegNakedSprite;
    }
    public void SetClothe(Sprite frontBodyClothe)
    {
        ShowClothe();
        frontBodyClothes.sprite = frontBodyClothe;
        InventoryFrontBodyClothes.sprite = frontBodyClothe;
    }

    public void ShowWeapon()
    {
        weaponSprite.enabled = true;
        InventoryWeaponSprite.enabled = true;
    }

    public void HideWeapon()
    {
        weaponSprite.enabled = false;
        InventoryWeaponSprite.enabled = false;
    }

    public void SetWeapon(Sprite newWeaponSprite)
    {
        ShowWeapon();
        weaponSprite.sprite = newWeaponSprite;
        InventoryWeaponSprite.sprite = newWeaponSprite;
    }
}
