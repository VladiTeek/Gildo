using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An Item that can be equipped. */

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{



    public EquipmentSlot equipSlot; // Slot to store equipment in

    //public int armorModifier;       // Increase/decrease in armor
    //public int damageModifier;      // Increase/decrease in damage
    //public SkinnedMeshRenderer mesh;
    //public Equipment_Manager.MeshBlendShape[] coveredMeshRegions;

    // When pressed in inventory
    public override void Use()
    {
        base.Use();
        Equipment_Manager.instance.Equip(this);  // Equip it
        RemoveFromInventory();                  // Remove it from inventory
    }

}

public enum EquipmentSlot { RightHand, LeftHand}