using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    Inventory_Slot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItenChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<Inventory_Slot>();
    }


    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}