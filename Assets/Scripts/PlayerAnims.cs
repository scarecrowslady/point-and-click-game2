using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    Animator playerAnims;

    //public GameObject itemHeld;
    //public Transform carryZone;

    public bool isCarrying;

    // Start is called before the first frame update
    void Start()
    {        
        playerAnims = transform.GetComponent<Animator>();
        //carryZone = itemHeld.GetComponent<Transform>();

        playerAnims.SetBool("isWalking", false);
        playerAnims.SetBool("isHolding", false);

        isCarrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerAnims.SetBool("isWalking", true);
            playerAnims.SetTrigger("triW");
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            playerAnims.SetBool("isWalking", true);
            playerAnims.SetTrigger("triS");
        } else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnims.SetBool("isWalking", false);
        }

        if(isCarrying == true)
        {
            playerAnims.SetBool("isHolding", true);
        }
        if(isCarrying == false)
        {
            playerAnims.SetBool("isHolding", false);
        }
    }

    public void CarryingItem()
    {
        isCarrying = true;
    }
    public void NotCarryingItem()
    {
        isCarrying = false;
    }
}
