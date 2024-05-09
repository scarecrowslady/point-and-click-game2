using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Scriptable Object/Database")]
public class InventoryDatabaseObject : ScriptableObject
{
    public Item[] itemsList = new Item[42];

    public Item GetItem(int itemID)
    {
        foreach (var itemdata in itemsList)
        {
            if (itemdata != null && itemdata.ID == itemID) 
                
                return itemdata;
        }
        return null;
    }
}
