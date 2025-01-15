using UnityEngine;

public class TouchInputSlide : MonoBehaviour
{
    private Rect touchAreaLeft,touchAreaRight; // Область, в которой будет проверяться нажатие
    [SerializeField] private GameObject cam, leftArrow, rightArrow; //Камера
    [SerializeField] private float cameraSpeedChange, leftSideMax, rightSideMax; //Переменные скорости перемещения камеры, и границы перемещения камеры
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary)
            {
                Vector2 touchPosition = touch.position;
               
                if (touchAreaLeft.Contains(touchPosition))  // Проверяем, находится ли нажатие в левой заданной части
                {
                     ChangePosionCamera(false);
                }

                if (touchAreaRight.Contains(touchPosition)) // Проверяем, находится ли нажатие в правой заданной части
                {
                     ChangePosionCamera(true);
                }
            }
        }
    }
    void Awake()
    {
        touchAreaLeft = new Rect(leftArrow.transform.position.x-100, 0, 200, 2000);  //Настройка областей нажатия для скрола влево
        touchAreaRight = new Rect(rightArrow.transform.position.x-100, 0, 200, 2000);   //Настройка областей нажатия для скрола вправо
    }
    void OnDrawGizmosSelected() //Показ области нажатия в редакторе
    {
        Gizmos.color = Color.red; // Область нажатия в редакторе для удобства
        Gizmos.DrawWireCube(new Vector3(touchAreaLeft.center.x, touchAreaLeft.center.y, 0), touchAreaLeft.size); // Область нажатия для скрола в левой части
        Gizmos.DrawWireCube(new Vector3(touchAreaRight.center.x, touchAreaRight.center.y, 0), touchAreaRight.size); // Область нажатия для скрола в правой части
        Gizmos.color = Color.blue; // Область нажатия в редакторе для удобства
        //Gizmos.DrawWireCube(new Vector3(-xMax * 9/10, 0, 0), new Vector3(xMax/5, yMax/2,10)); // Область нажатия для скрола в левой части
        //Gizmos.DrawWireCube(new Vector3(Screen.width*9/10, Screen.height, 0), new Vector3(Screen.width/5,Screen.height,10)); // Область нажатия для скрола в правой части
    }

    void ChangePosionCamera(bool right) //Движение камеры при нажатии
    {
        if (right)
        {
            cam.transform.Translate(cameraSpeedChange/40,0,0); // Перемещение камеры вправо
        }
        else
        {
            cam.transform.Translate(-cameraSpeedChange/40,0,0); // Перемещение камеры влево
        }
        cam.transform.position = new Vector3(Mathf.Clamp(cam.transform.position.x, leftSideMax, rightSideMax),cam.transform.position.y,cam.transform.position.z); //Проверка того, что бы камеры не зашла за границы
    }

}
