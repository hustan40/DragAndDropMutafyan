using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Interact"))
        {
            DropItem dropItem = other.GetComponent<DropItem>(); 
            dropItem.isStay = true; //Делаем объект недвижимым
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interact"))
        {
            DropItem dropItem = other.GetComponent<DropItem>(); 
            dropItem.isStay = false; //Разрешаем объекту двигаться
        }
    }
}
