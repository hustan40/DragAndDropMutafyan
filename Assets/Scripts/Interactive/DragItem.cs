
using Unity.VisualScripting;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private DropItem dropItem;
    public bool isDragged = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (isDragged | dropItem.isStay) //Проверяем взят ли предмет игроков или предмет находится в зоне стояния (полки например)
        {
            rb.isKinematic = true; //Включаем кинематику
            rb.velocity = Vector3.zero; // Убираем возможные оставшиеся ускорения
        }
        else if(!isDragged) //Проверяем взят ли предмет игроком
        {
            rb.isKinematic = false;
        }
        isDragged = false;
    }
    public void MoveObject(Vector2 touchPosition)
    {
        isDragged = true;
        transform.position = new Vector3(touchPosition.x, touchPosition.y, transform.position.z); //Меняет положение объекта следом за местом касания
    }
}
