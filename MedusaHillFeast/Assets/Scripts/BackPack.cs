using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour {
    public List<ItemObject> items;

    public bool checkIng(Ingredients ingR)
    {
        bool result = false;

        Debug.Log("checking cook: " + ingR.ingID);
        for (int i = 0; i < items.Count; i++)
        {
            if (ingR.ingID == items[i].itemID)
            {
                Debug.Log("checking ingredient: " + items[i].itemName);
                if (ingR.ingNum <= items[i].itemNumber)
                {
                    result = true;
                    Debug.Log("ingredient " + items[i].itemName + " checked");
                }
                else
                {
                    Debug.Log("ingredient " + items[i].itemName + " not enough");
                    return false;
                }
            }
        }

        return result;
    }

    public void removeItem(int itemID, int amountRemoved)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (itemID == items[i].itemID)
            {
                items[i].itemNumber -= amountRemoved;
                if (items[i].itemNumber <= 0) items.Remove(items[i]);
            }
        }
    }

    public void addItem(ItemObject item)
    {
        bool exist = false;

        for(int i=0;i< items.Count; i++)
        {
            if (items[i].itemID == item.itemID)
            {
                items[i].itemNumber += item.itemNumber;
                exist = true;
            }
        }

        if(!exist)  items.Add(item);
    }
}
