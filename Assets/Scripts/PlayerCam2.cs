using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using Cinemachine;

public class PlayerCam : MonoBehaviour
{
    //triggering interactables
    public GameObject interactableObject;
    public float raycastLength;

    //dealing with inventory
    public GameObject mainInventoryGroup;
    public Texture2D handCursor;
    public Texture2D magGlassCursor;
    public Texture2D dotCursor;

    public bool canClick;

    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            canClick = false;

            Cursor.SetCursor(dotCursor, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            FindingStuff();
        }
        else
        {
            canClick = true;

            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            PickStuffUp();
        }
    }

    public void FindingStuff()
    {
        //raycasting for interactable objects
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 5f);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, raycastLength))
        {
            if (hitData.transform.CompareTag("interactable"))
            {
                Cursor.SetCursor(magGlassCursor, Vector2.zero, CursorMode.Auto);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
                //Debug.Log("i hit something interactable");
            } 
            else if (hitData.transform.CompareTag("pickupable"))
            {
                Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.Auto);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
                //Debug.Log("i hit something pickupable");
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void PickStuffUp()
    {
        if (canClick == true)
        {
            //raycasting for interactable objects
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * raycastLength);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData, raycastLength))
            {
                if (hitData.transform.CompareTag("pickupable"))
                {
                    //Debug.Log(hitData.transform.ToString());

                    hitData.transform.GetComponent<InteractableItem>().PickupItem();
                }
                else if (hitData.transform.CompareTag("interactable"))
                {
                    hitData.transform.GetComponent<InteractableItem>().InteractWithItem();
                }
            }
        }
    }
}
