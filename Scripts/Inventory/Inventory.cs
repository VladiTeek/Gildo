using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion



    public delegate void OnItemChanged();
    public OnItemChanged onItenChangedCallback;

    public int space = 25;

    public List<Item> items = new List<Item>();

    public Item itemWood;
    public Item itemRock;

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enought room");
                return false;
            }

            items.Add(item);

            if (onItenChangedCallback != null)
            onItenChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove (Item item)
    {
        if(item == itemWood)
        {
            items.Remove(item);
            if (onItenChangedCallback != null)
                onItenChangedCallback.Invoke();
            PickUpRes.wood -= 1;

        }
        else if (item == itemRock)
        {
            items.Remove(item);
            if (onItenChangedCallback != null)
                onItenChangedCallback.Invoke();
            PickUpRes.rock -= 1;
        }
        else
        {
            items.Remove(item);
            if (onItenChangedCallback != null)
                onItenChangedCallback.Invoke();
        }
    }

}
