using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    public bool isStay = false;
    
    void FixedUpdate()
    {
        if (isStay) //Проверяем находится ли объект в точке не передвижения
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        }
        else if(!isStay)
        {
            rb.isKinematic = false;
        }
    }
}
