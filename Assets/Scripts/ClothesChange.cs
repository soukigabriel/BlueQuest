using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesChange : MonoBehaviour
{

    [Header("Front Clothes Sprites")]
    public Sprite frontHatSpriteOne;
    public Sprite frontHatSpriteTwo;
    public Sprite frontBodyClotheSpriteOne;
    public Sprite frontBodyClotheSpriteTwo;
    public Sprite frontLeftArmClotheSprite;
    public Sprite frontRightArmClotheSprite;
    public Sprite frontLeftLegClotheSprite;
    public Sprite frontRightLegClotheSprite;

    [Space]
    [Header("Front Naked Sprites")]
    public Sprite frontLeftArmNakedSprite;
    public Sprite frontRightArmNakedSprite;
    public Sprite frontLeftLegNakedSprite;
    public Sprite frontRightLegNakedSprite;

    [Space]
    [Header("Front character reference Sprites")]
    public SpriteRenderer frontHat;
    public SpriteRenderer frontBodyClothes;
    public SpriteRenderer frontLeftArm;
    public SpriteRenderer frontRightArm;
    public SpriteRenderer frontWeaponSprite;
    public SpriteRenderer frontLeftLeg;
    public SpriteRenderer frontRightLeg;

    [Space]
    [Header("UI character Sprites")]
    public SpriteRenderer InventoryFrontHat;
    public SpriteRenderer InventoryFrontBodyClothes;
    public SpriteRenderer InventoryFrontLeftArm;
    public SpriteRenderer InventoryFrontRightArm;
    public SpriteRenderer InventoryWeaponSprite;
    public SpriteRenderer InventoryFrontLeftLeg;
    public SpriteRenderer InventoryFrontRightLeg;


    [Space]
    [Header("Back character reference Sprites")]
    public SpriteRenderer backHat;
    public SpriteRenderer backBodyClothes;
    public SpriteRenderer backLeftArm;
    public SpriteRenderer backRightArm;
    public SpriteRenderer backWeaponSprite;
    public SpriteRenderer backLeftLeg;
    public SpriteRenderer backRightLeg;

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

    [Space]
    [Header("Back Naked Sprites")]
    public Sprite backLeftArmNakedSprite;
    public Sprite backRightArmNakedSprite;
    public Sprite backLeftLegNakedSprite;
    public Sprite backRightLegNakedSprite;


    [Space]
    [Header("Left character reference Sprites")]
    public SpriteRenderer leftHat;
    public SpriteRenderer leftBodyClothes;
    public SpriteRenderer leftLeftArm;
    public SpriteRenderer leftRightArm;
    public SpriteRenderer leftWeaponSprite;
    public SpriteRenderer leftLeftLeg;
    public SpriteRenderer leftRightLeg;

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

    [Space]
    [Header("Left Naked Sprites")]
    public Sprite leftLeftArmNakedSprite;
    public Sprite leftRightArmNakedSprite;
    public Sprite leftLeftLegNakedSprite;
    public Sprite leftRightLegNakedSprite;


    [Space]
    [Header("Right character reference Sprites")]
    public SpriteRenderer rightHat;
    public SpriteRenderer rightBodyClothes;
    public SpriteRenderer rightLeftArm;
    public SpriteRenderer rightRightArm;
    public SpriteRenderer rightWeaponSprite;
    public SpriteRenderer rightLeftLeg;
    public SpriteRenderer rightRightLeg;

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

    [Space]
    [Header("Right Naked Sprites")]
    public Sprite rightLeftArmNakedSprite;
    public Sprite rightRightArmNakedSprite;
    public Sprite rightLeftLegNakedSprite;
    public Sprite rightRightLegNakedSprite;

    //Hat
    public void ShowHat()
    {
        frontHat.enabled = true;
        InventoryFrontHat.enabled = true;
        backHat.enabled = true;
        leftHat.enabled = true;
        rightHat.enabled = true;
    }
    public void HideHat()
    {
        frontHat.enabled = false;
        InventoryFrontHat.enabled = false;
        backHat.enabled = false;
        leftHat.enabled = false;
        rightHat.enabled = false;
    }
    public void SetHatOne()
    {
        frontHat.sprite = frontHatSpriteOne;
        InventoryFrontHat.sprite = frontHatSpriteOne;
        backHat.sprite = backHatSpriteOne;
        leftHat.sprite = leftHatSpriteOne;
        rightHat.sprite = rightHatSpriteOne;
    }

    public void SetHatTwo()
    {
        frontHat.sprite = frontHatSpriteTwo;
        InventoryFrontHat.sprite = frontHatSpriteTwo;
        backHat.sprite = backHatSpriteTwo;
        leftHat.sprite = leftHatSpriteTwo;
        rightHat.sprite = rightHatSpriteTwo;
    }


    //Clothes
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
        ShowClothe();
        frontBodyClothes.sprite = frontBodyClotheSpriteOne;
        InventoryFrontBodyClothes.sprite = frontBodyClotheSpriteOne;
        backBodyClothes.sprite = backBodyClotheSpriteOne;
        leftBodyClothes.sprite = leftBodyClotheSpriteOne;
        rightBodyClothes.sprite = rightBodyClotheSpriteOne;
    }

    public void SetClotheTwo()
    {
        ShowClothe();
        frontBodyClothes.sprite = frontBodyClotheSpriteTwo;
        InventoryFrontBodyClothes.sprite = frontBodyClotheSpriteTwo;
        backBodyClothes.sprite = backBodyClotheSpriteTwo;
        leftBodyClothes.sprite = leftBodyClotheSpriteTwo;
        rightBodyClothes.sprite = rightBodyClotheSpriteTwo;
    }

    public void ShowWeapon()
    {
        frontWeaponSprite.enabled = true;
        InventoryWeaponSprite.enabled = true;
        backWeaponSprite.enabled = true;
        leftWeaponSprite.enabled = true;
        rightWeaponSprite.enabled = true;
    }

    public void HideWeapon()
    {
        frontWeaponSprite.enabled = false;
        InventoryWeaponSprite.enabled = false;
        backWeaponSprite.enabled = false;
        leftWeaponSprite.enabled = false;
        rightWeaponSprite.enabled = false;
    }

    public void SetWeapon(Sprite newWeaponSprite)
    {
        ShowWeapon();
        frontWeaponSprite.sprite = newWeaponSprite;
        InventoryWeaponSprite.sprite = newWeaponSprite;
        backWeaponSprite.sprite = newWeaponSprite;
        leftWeaponSprite.sprite = newWeaponSprite;
        rightWeaponSprite.sprite = newWeaponSprite;
    }
}
