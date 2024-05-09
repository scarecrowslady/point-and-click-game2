using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item itemSO;

    public GameObject gameManagerGO;

    public bool isPickupAble;
    public bool isCarryAble;
    public bool isBook;

    public bool carrySlotIsEmpty;
    public int itemheldAN;

    public Transform goHeldZone;
      
    public void Start()
    {
        isPickupAble = itemSO.pickupAble;
        isCarryAble = itemSO.carryAble;
        isBook = itemSO.isBook;

        itemheldAN = itemSO.itemheldAN;
    }

    public void Update()
    {
        if (gameObject.CompareTag("carried") == true)
        {
            if (itemSO.isBeingCarried == true && carrySlotIsEmpty == false)
            {
                //itemHeld.SetActive(true);
            }
        }        
    }

    public void PickupItem()
    {
        if (isPickupAble == true)
        {
            inventoryManager.AddItem(itemSO);

            Destroy(gameObject);
        } 
    }

    public void InteractWithItem()
    {
        Debug.Log("I am interactable");
    }
}
