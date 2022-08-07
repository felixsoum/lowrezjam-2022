using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class WeaponConfig : ScriptableObject


{
    [SerializeField] Sprite characterBody = null;
    [SerializeField] Plants equippedPrefab = null;
    [SerializeField] Sprite noOutline;
    [SerializeField] Sprite withOutline;
    [SerializeField] AnimatorOverrideController animatorOverride = null;

    const string weaponName = "Weapon";

    public Plants Spawn(Transform handPosition, Animator animator, SpriteRenderer body)
    {
        Plants weapon = null;
        DestroyOldWeapon(handPosition);
        if (equippedPrefab != null)
        {

            Transform handTransform = GetTansform(handPosition);
            weapon = Instantiate(equippedPrefab, handTransform);
            weapon.gameObject.name = weaponName;


        }
        var overriderController = animator.runtimeAnimatorController as AnimatorOverrideController;
        if (animatorOverride != null)
        {
            animator.runtimeAnimatorController = animatorOverride;
        }
        else if (overriderController != null) //control if is already overrided
        {
            animator.runtimeAnimatorController = overriderController.runtimeAnimatorController;
        }
        var bodySprite = body;

        if (characterBody != null)
        {
            body.sprite = characterBody;
        }


        return weapon;

    }

    public Sprite NotOutline()
    {
        if (noOutline == null) return null;
        return noOutline;
    }
    public Sprite WithOutline()
    {
        if (noOutline == null) return null;
        return withOutline;
    }



    private Transform GetTansform(Transform handPosition)
    {
        Transform handTransform;
        handTransform = handPosition;
        return handTransform;
    }


    private void DestroyOldWeapon(Transform handposition)
    {
        Transform oldWeapon = handposition.Find(weaponName);

        if (oldWeapon == null) return;

        oldWeapon.name = "Destroying";
        Destroy(oldWeapon.gameObject);
    }





}
