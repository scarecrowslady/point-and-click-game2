using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   
    [Header("UI")]
    public Image image;
    public GameObject nmbrBkgrd;
    public TMP_Text countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitializeItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        nmbrBkgrd.SetActive(false);
        RefreshCount();
    }

    public void RefreshCount()
    {
        countText.text = count.ToString();

        bool textActive = count > 1;

        if(textActive == true)
        {
            nmbrBkgrd.SetActive(true);
            countText.gameObject.SetActive(textActive);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin drag");
        countText.raycastTarget = false;
        nmbrBkgrd.SetActive(false);

        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;        
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        countText.raycastTarget = true;
        //nmbrBkgrd.SetActive(true);
        RefreshCount();
    }
}
