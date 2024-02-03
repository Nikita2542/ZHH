using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotation : MonoBehaviour
{
    [Space(5)]
    [Tooltip("Назначь обьект который будет вращаться")]
    public GameObject Car_Rot;
    [Space(10)]
    [Tooltip("Скорость вращения")]
    public float sensitivity = 3.0f;
    [Space(5)]
    [Tooltip("Время вращения к начатьной позиции")]
    public float timeReturn = 1.0f;
    [Tooltip("Время - ожидание")]
    public float timeDuration = 3.0f;

    RectTransform Rect_21;
    Vector2 turn;
    [HideInInspector] public Quaternion rotationOriginal;

    float timeRotate;
    bool start;
    bool end;
    public bool endComp;

    void Start()
    {


        rotationOriginal = Car_Rot.transform.localRotation; // Запоминаем начальное вращение
        Rect_21 = GetComponent<RectTransform>();
    }


    void Update()
    {

        if (RectTransformUtility.RectangleContainsScreenPoint(Rect_21, Input.mousePosition))
        {

            if (Input.GetMouseButton(0)) // Удерживаем правую кнопку мыши
            {

                end = false;
                turn.x += Input.GetAxis("Mouse X") * sensitivity;
                //turn.y += Input.GetAxis("Mouse Y") * sensitivity;

                Car_Rot.transform.localRotation = Quaternion.Euler(0, -turn.x, 0);

                start = false; // Отмена "времени ожидания"

                Cursor.lockState = CursorLockMode.Locked; // Блокировка курсора
            }
            if (Input.GetMouseButtonUp(0)) // Отпускаем правую кнопку мыши
            {
                timeRotate = 0.0f;
                start = true; // Запуск "времени ожидания"

                Cursor.lockState = CursorLockMode.None; // Разблокировка курсора
            }
        }
        // Включается "Время ожидания" - timeDuration
        if (start)
        {
            if (timeRotate < timeDuration)
            {
                timeRotate += Time.deltaTime;
            }
            if (timeRotate >= timeDuration)
            {
                timeRotate = 0.0f;
                end = true; // Включается "возвращение на родину"
                start = false;
            }
        }
        // Вовращение на родину
        if (end)
        {
            // Возвращается к начальной позиции
            Car_Rot.transform.localRotation = Quaternion.Lerp(Car_Rot.transform.localRotation, rotationOriginal, Time.deltaTime / timeReturn);

            turn.x = Car_Rot.transform.localRotation.y; // Сброс координат мыши
            //turn.y = Car_Rot.transform.localRotation.z; // Сброс координат мыши

            if (Car_Rot.transform.localRotation == rotationOriginal)
            {
                end = false;
            }
        }
       
    }
}
