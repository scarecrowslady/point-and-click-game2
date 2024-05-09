using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]
public class InventoryManager : MonoBehaviour, ISerializationCallbackReceiver
{
    public static InventoryManager InventoryInstance;

    public int maxStackedItems = 10;
    public int carrySlotCount = 10;

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public GameObject[] carryItems;

    public GameObject[] bookshelfItems;
    public string bookName;

    int selectedSlot = -1;

    public GameObject playerRB;
    public GameObject carrySlot;

    public const int numSlots = 42;
    public Item[] items = new Item[numSlots];
    [HideInInspector] public int[] itemIDs = new int[numSlots];
    public InventoryDatabaseObject inventoryDatabaseObject;

    public bool AddItem(Item item)
    {
        if(item.isBook == true)
        {
            for(int i = 0; i < bookshelfItems.Length; i++)
            {
                //return GameObject if name matches
                if (bookshelfItems[i].GetComponent<BookButtons>().bookName == item.goName)
                {
                    bookshelfItems[i].SetActive(true);

                    SaveManager.Instance.SaveInfo();

                    return true;
                }
            }

            return false;
        } else
        {
            //check if any slot has the same item with count lower than max
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                DraggableItem iteminslot = slot.GetComponentInChildren<DraggableItem>();

                if (slot.name != "Carry Slot")
                {
                    if (iteminslot != null &&
                    iteminslot.item == item &&
                    iteminslot.count < maxStackedItems &&
                    iteminslot.item.stackable == true)
                    {
                        iteminslot.count++;
                        iteminslot.RefreshCount();

                        return true;
                    }
                }
            }

            //find any empty slot
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                InventorySlot slot = inventorySlots[i];
                DraggableItem iteminslot = slot.GetComponentInChildren<DraggableItem>();

                if (slot.name != "Carry Slot")
                {
                    if (iteminslot == null)
                    {
                        SpawnNewItem(item, slot);
                        return true;
                    }
                }
            }
        }     

        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DraggableItem inventoryItem = newItemGo.GetComponent<DraggableItem>();
        inventoryItem.InitializeItem(item);

        SaveManager.Instance.SaveInfo();
    }

    public Item GetSelectedItem()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        DraggableItem iteminslot = slot.GetComponentInChildren<DraggableItem>();
        if (iteminslot != null)
        {
            return iteminslot.item;
        }

        return null;
    }

    // Copy item IDs from items[] to itemIDs[].
    public void OnBeforeSerialize()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            var itemID = (items[i] != null) ? items[i].ID : -1;
            itemIDs[i] = itemID;
        }

    }

    // Fill items[] from itemIDs[].
    public void OnAfterDeserialize()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            var item = inventoryDatabaseObject.GetItem(itemIDs[i]);
            if (item == null)
            {
                items[i] = null;
                //itemImages[i].sprite = null;
                //itemNames[i].text = string.Empty;
                //itemImages[i].enabled = false;
            }
            else
            {
                items[i] = item;
                //itemImages[i].sprite = item.itemSprite;
                //itemNames[i].text = item.itemName;
                //itemImages[i].enabled = true;
            }
        }
    }
}
