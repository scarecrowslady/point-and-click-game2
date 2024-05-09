using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_GeneralMovement : MonoBehaviour
{   
    void Update()
    {
        gameObject.transform.Rotate(0, 0.05f, 0);
    }
}
