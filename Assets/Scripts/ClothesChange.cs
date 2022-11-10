using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesChange : MonoBehaviour
{
    //The sprites that will be applied to the front of the character when the clothes are selected
    [Header("Front Clothes Sprites")]
    public Sprite frontHatSpriteOne;
    public Sprite frontHatSpriteTwo;
    public Sprite frontBodyClotheSpriteOne;
    public Sprite frontBodyClotheSpriteTwo;
    public Sprite frontLeftArmClotheSprite;
    public Sprite frontRightArmClotheSprite;
    public Sprite frontLeftLegClotheSprite;
    public Sprite frontRightLegClotheSprite;

    //The sprites that will be applied to the front of the character when the clothes are deselected
    [Space]
    [Header("Front Naked Sprites")]
    public Sprite frontLeftArmNakedSprite;
    public Sprite frontRightArmNakedSprite;
    public Sprite frontLeftLegNakedSprite;
    public Sprite frontRightLegNakedSprite;

    //The sprites of each part of the front of the current character
    [Space]
    [Header("Front character reference Sprites")]
    public SpriteRenderer frontHat;
    public SpriteRenderer frontBodyClothes;
    public SpriteRenderer frontLeftArm;
    public SpriteRenderer frontRightArm;
    public SpriteRenderer frontWeaponSprite;
    public SpriteRenderer frontLeftLeg;
    public SpriteRenderer frontRightLeg;

    //The sprites of each part of the UI character
    [Space]
    [Header("UI character Sprites")]
    public SpriteRenderer InventoryFrontHat;
    public SpriteRenderer InventoryFrontBodyClothes;
    public SpriteRenderer InventoryFrontLeftArm;
    public SpriteRenderer InventoryFrontRightArm;
    public SpriteRenderer InventoryWeaponSprite;
    public SpriteRenderer InventoryFrontLeftLeg;
    public SpriteRenderer InventoryFrontRightLeg;


    //The sprites of each part of the back of the current character
    [Space]
    [Header("Back character reference Sprites")]
    public SpriteRenderer backHat;
    public SpriteRenderer backBodyClothes;
    public SpriteRenderer backLeftArm;
    public SpriteRenderer backRightArm;
    public SpriteRenderer backWeaponSprite;
    public SpriteRenderer backLeftLeg;
    public SpriteRenderer backRightLeg;

    //The sprites that will be applied to the back of the character when the clothes are selected
    [Space]
    [Header("Back Clothes Sprites")]
    public Sprite backHatSpriteOne;
    public Sprite backHatSpriteTwo;
    public Sprite backBodyClotheSpriteOne;
    public Sprite backBodyClotheSpriteTwo;
    public Sprite backLeftArmClotheSprite;
    public Sprite backRightArmClotheSprite;
    public Sprite backLeftLegClotheSprite;
    public Sprite backRightLegClotheSprite;

    //The sprites that will be applied to the back of the character when the clothes are deselected
    [Space]
    [Header("Back Naked Sprites")]
    public Sprite backLeftArmNakedSprite;
    public Sprite backRightArmNakedSprite;
    public Sprite backLeftLegNakedSprite;
    public Sprite backRightLegNakedSprite;


    //The sprites of each part of the left of the current character
    [Space]
    [Header("Left character reference Sprites")]
    public SpriteRenderer leftHat;
    public SpriteRenderer leftBodyClothes;
    public SpriteRenderer leftLeftArm;
    public SpriteRenderer leftRightArm;
    public SpriteRenderer leftWeaponSprite;
    public SpriteRenderer leftLeftLeg;
    public SpriteRenderer leftRightLeg;

    //The sprites that will be applied to the left of the character when the clothes are selected
    [Space]
    [Header("Left Clothes Sprites")]
    public Sprite leftHatSpriteOne;
    public Sprite leftHatSpriteTwo;
    public Sprite leftBodyClotheSpriteOne;
    public Sprite leftBodyClotheSpriteTwo;
    public Sprite leftLeftArmClotheSprite;
    public Sprite leftRightArmClotheSprite;
    public Sprite leftLeftLegClotheSprite;
    public Sprite leftRightLegClotheSprite;

    //The sprites that will be applied to the left of the character when the clothes are deselected
    [Space]
    [Header("Left Naked Sprites")]
    public Sprite leftLeftArmNakedSprite;
    public Sprite leftRightArmNakedSprite;
    public Sprite leftLeftLegNakedSprite;
    public Sprite leftRightLegNakedSprite;


    //The sprites of each part of the right of the current character
    [Space]
    [Header("Right character reference Sprites")]
    public SpriteRenderer rightHat;
    public SpriteRenderer rightBodyClothes;
    public SpriteRenderer rightLeftArm;
    public SpriteRenderer rightRightArm;
    public SpriteRenderer rightWeaponSprite;
    public SpriteRenderer rightLeftLeg;
    public SpriteRenderer rightRightLeg;

    //The sprites that will be applied to the right of the character when the clothes are selected
    [Space]
    [Header("Right Clothes Sprites")]
    public Sprite rightHatSpriteOne;
    public Sprite rightHatSpriteTwo;
    public Sprite rightBodyClotheSpriteOne;
    public Sprite rightBodyClotheSpriteTwo;
    public Sprite rightLeftArmClotheSprite;
    public Sprite rightRightArmClotheSprite;
    public Sprite rightLeftLegClotheSprite;
    public Sprite rightRightLegClotheSprite;

    //The sprites that will be applied to the right of the character when the clothes are deselected
    [Space]
    [Header("Right Naked Sprites")]
    public Sprite rightLeftArmNakedSprite;
    public Sprite rightRightArmNakedSprite;
    public Sprite rightLeftLegNakedSprite;
    public Sprite rightRightLegNakedSprite;

    public Sprite swordOneSprite;
    public Sprite swordTwoSprite;



    public void EquipItem(ItemType theItem)
    {
        switch (theItem)
        {
            case ItemType.HatOne:
                SetHatOne();
                break;
            case ItemType.HatTwo:
                SetHatTwo();
                break;
            case ItemType.ClothesOne:
                SetClotheOne();
                break;
            case ItemType.ClothesTwo:
                SetClotheTwo();
                break;
            case ItemType.SwordOne:
                SetWeaponOne();
                break;
            case ItemType.SwordTwo:
                SetWeaponTwo();
                break;

            default:
                break;
        }
    }

    public void UnequipItem(ItemType theItem)
    {
        switch (theItem)
        {
            case ItemType.HatOne:
                HideHat();
                break;
            case ItemType.HatTwo:
                HideHat();
                break;
            case ItemType.ClothesOne:
                HideClothe();
                break;
            case ItemType.ClothesTwo:
                HideClothe();
                break;
            case ItemType.SwordOne:
                HideWeapon();
                break;
            case ItemType.SwordTwo:
                HideWeapon();
                break;

            default:
                break;
        }
    }


    //Hat methods
    public void ShowHat()
    {
        //Enable all the hat gameobjects
        frontHat.enabled = true;
        InventoryFrontHat.enabled = true;
        backHat.enabled = true;
        leftHat.enabled = true;
        rightHat.enabled = true;
    }
    public void HideHat()
    {
        //Enable all the hat gameobject
        frontHat.enabled = false;
        InventoryFrontHat.enabled = false;
        backHat.enabled = false;
        leftHat.enabled = false;
        rightHat.enabled = false;
    }
    public void SetHatOne()
    {
        ShowHat();
        //Change the current hat sprite with the Hat 1 sprite
        frontHat.sprite = frontHatSpriteOne;
        InventoryFrontHat.sprite = frontHatSpriteOne;
        backHat.sprite = backHatSpriteOne;
        leftHat.sprite = leftHatSpriteOne;
        rightHat.sprite = rightHatSpriteOne;
    }
    public void SetHatTwo()
    {
        ShowHat();
        //Change the current hat sprite with the Hat 2 sprite
        frontHat.sprite = frontHatSpriteTwo;
        InventoryFrontHat.sprite = frontHatSpriteTwo;
        backHat.sprite = backHatSpriteTwo;
        leftHat.sprite = leftHatSpriteTwo;
        rightHat.sprite = rightHatSpriteTwo;
    }


    //Clothes methods
    public void ShowClothe()
    {
        //Show front character clothe
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

        //Show back character clothe
        backBodyClothes.enabled = true;
        backLeftArm.sprite = backLeftArmClotheSprite;
        backRightArm.sprite = backRightArmClotheSprite;
        backLeftLeg.sprite = backLeftLegClotheSprite;
        backRightLeg.sprite = backRightLegClotheSprite;

        //Show left character clothe
        leftBodyClothes.enabled = true;
        leftLeftArm.sprite = leftLeftArmClotheSprite;
        leftRightArm.sprite = leftRightArmClotheSprite;
        leftLeftLeg.sprite = leftLeftLegClotheSprite;
        leftRightLeg.sprite = leftRightLegClotheSprite;

        //Show right character clothe
        rightBodyClothes.enabled = true;
        rightLeftArm.sprite = rightLeftArmClotheSprite;
        rightRightArm.sprite = rightRightArmClotheSprite;
        rightLeftLeg.sprite = rightLeftLegClotheSprite;
        rightRightLeg.sprite = rightRightLegClotheSprite;
    }
    public void HideClothe()
    {
        //Hide front character clothe
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

        //Hide back character clothe
        backBodyClothes.enabled = false;
        backLeftArm.sprite = backLeftArmNakedSprite;
        backRightArm.sprite = backRightArmNakedSprite;
        backLeftLeg.sprite = backLeftLegNakedSprite;
        backRightLeg.sprite = backRightLegNakedSprite;

        //Hide left character clothe
        leftBodyClothes.enabled = false;
        leftLeftArm.sprite = leftLeftArmNakedSprite;
        leftRightArm.sprite = leftRightArmNakedSprite;
        leftLeftLeg.sprite = leftLeftLegNakedSprite;
        leftRightLeg.sprite = leftRightLegNakedSprite;

        //Hide right character clothe
        rightBodyClothes.enabled = false;
        rightLeftArm.sprite = rightLeftArmNakedSprite;
        rightRightArm.sprite = rightRightArmNakedSprite;
        rightLeftLeg.sprite = rightLeftLegNakedSprite;
        rightRightLeg.sprite = rightRightLegNakedSprite;

    }
    public void SetClotheOne()
    {
        //Show the clothes and then change the current sprites of the character with the clothes 1
        ShowClothe();
        frontBodyClothes.sprite = frontBodyClotheSpriteOne;
        InventoryFrontBodyClothes.sprite = frontBodyClotheSpriteOne;
        backBodyClothes.sprite = backBodyClotheSpriteOne;
        leftBodyClothes.sprite = leftBodyClotheSpriteOne;
        rightBodyClothes.sprite = rightBodyClotheSpriteOne;
    }

    public void SetClotheTwo()
    {
        //Show the clothes and then change the current sprites of the character with the clothes 2
        ShowClothe();
        frontBodyClothes.sprite = frontBodyClotheSpriteTwo;
        InventoryFrontBodyClothes.sprite = frontBodyClotheSpriteTwo;
        backBodyClothes.sprite = backBodyClotheSpriteTwo;
        leftBodyClothes.sprite = leftBodyClotheSpriteTwo;
        rightBodyClothes.sprite = rightBodyClotheSpriteTwo;
    }

    //Weapon methods
    public void ShowWeapon()
    {
        //Enable every weapon of the character
        frontWeaponSprite.enabled = true;
        InventoryWeaponSprite.enabled = true;
        backWeaponSprite.enabled = true;
        leftWeaponSprite.enabled = true;
        rightWeaponSprite.enabled = true;
    }

    public void HideWeapon()
    {
        //Disable every weapon of the character
        frontWeaponSprite.enabled = false;
        InventoryWeaponSprite.enabled = false;
        backWeaponSprite.enabled = false;
        leftWeaponSprite.enabled = false;
        rightWeaponSprite.enabled = false;
    }
    public void SetWeaponOne()
    {
        //Show the weapon and then change it's current sprite with a new one passed through parameter
        ShowWeapon();
        frontWeaponSprite.sprite = swordOneSprite;
        InventoryWeaponSprite.sprite = swordOneSprite;
        backWeaponSprite.sprite = swordOneSprite;
        leftWeaponSprite.sprite = swordOneSprite;
        rightWeaponSprite.sprite = swordOneSprite;
    }
    public void SetWeaponTwo()
    {
        //Show the weapon and then change it's current sprite with a new one passed through parameter
        ShowWeapon();
        frontWeaponSprite.sprite = swordTwoSprite;
        InventoryWeaponSprite.sprite = swordTwoSprite;
        backWeaponSprite.sprite = swordTwoSprite;
        leftWeaponSprite.sprite = swordTwoSprite;
        rightWeaponSprite.sprite = swordTwoSprite;
    }
}
