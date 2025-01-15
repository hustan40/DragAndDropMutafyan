using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMain : MonoBehaviour
{
    Touch touch;
    void Update()
    {
        if (Input.touchCount > 0 )
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved | touch.phase == TouchPhase.Stationary) //Смотрим точку ввода касания в момент движения или неподвижности
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); //Сохраняем координату в 2д векторе
                Collider2D hit = Physics2D.OverlapPoint(touchPosition); // Проверяем касается ли вводная координата каких либо объектов

                if (hit != null)
                {
                    DragItem dragItem = hit.GetComponent<DragItem>();  //Получаем код на перемещение объекта

                    if (dragItem != null)
                    {
                        dragItem.MoveObject(touchPosition); //Перемещаем объект
                    }
                }
            }
        }
    }
}
