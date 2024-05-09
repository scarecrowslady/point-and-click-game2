using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;

    public GameObject playerRB;
    PlayerAnims playerAnims;

    public GameObject itemCarried;

    public GameObject inventoryManagerGO;
    public GameObject[] carryItems;
    public int carryItemArrayNum;

    private void Awake()
    {
        Deselect();

        InventoryManager inventoryManager = inventoryManagerGO.GetComponent<InventoryManager>();
        carryItems = inventoryManager.carryItems;
    }

    public void Start()
    {
        playerAnims = playerRB.GetComponentInChildren<PlayerAnims>();
    }

    public void Update()
    {
        CheckCarrySlot();
    }

    public void Select()
    {
        this.image.color = selectedColor;
    }
    public void Deselect()
    {
        this.image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0 &&
            transform.name != "Carry Slot")
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
        else if (transform.childCount == 0 &&
            transform.name == "Carry Slot")
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            if (draggableItem.item.carryAble == true)
            {
                draggableItem.parentAfterDrag = transform;
                draggableItem.item.isBeingCarried = true;

                carryItemArrayNum = draggableItem.item.itemheldAN;

                ItemSetActive();

                //telling player anims that we are carrying something
                playerAnims.CarryingItem();
            }
        }
    }

    public void CheckCarrySlot()
    {
        if (transform.name == "Carry Slot" &&
            transform.childCount == 0)
        {            
            ItemSetInactive();

            playerAnims.NotCarryingItem();
        }
    }

    public void ItemSetActive()
    {
        itemCarried = carryItems[carryItemArrayNum];

        itemCarried.SetActive(true);
    }
    public void ItemSetInactive()
    {
        itemCarried = carryItems[carryItemArrayNum];

        itemCarried.SetActive(false);
    }
}
