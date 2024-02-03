using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    
    [Space(5)]
    [Tooltip("������� ������ ������� ����� ���������")]
    public GameObject Gun_Rot;
    [Space(10)]
    [Tooltip("�������� ��������")]
    public float sensitivity = 3.0f;
    [Space(5)]
    [Tooltip("����� �������� � ��������� �������")]
    public float timeReturn = 1.0f;
    [Tooltip("����� - ��������")]
    public float timeDuration = 3.0f;

    RectTransform Rect_21;
    Vector2 turn;
    Quaternion rotationOriginal;

    float timeRotate;
    bool start;
    bool end;

    void Start()
    {
       
       
        rotationOriginal = Gun_Rot.transform.localRotation; // ���������� ��������� ��������
        Rect_21 = GetComponent<RectTransform>();
    }


    void Update()
    {
        
        if (RectTransformUtility.RectangleContainsScreenPoint(Rect_21, Input.mousePosition))
        {

            if (Input.GetMouseButton(0)) // ���������� ������ ������ ����
            {
                
                end = false;
                turn.x += Input.GetAxis("Mouse X") * sensitivity;
                turn.y += Input.GetAxis("Mouse Y") * sensitivity;
                
                Gun_Rot.transform.localRotation = Quaternion.Euler(-turn.y, -turn.x, 0);

                start = false; // ������ "������� ��������"

                Cursor.lockState = CursorLockMode.Locked; // ���������� �������
            }
            if (Input.GetMouseButtonUp(0)) // ��������� ������ ������ ����
            {
                timeRotate = 0.0f; 
                start = true; // ������ "������� ��������"

               Cursor.lockState = CursorLockMode.None; // ������������� �������
            }    
        }
        // ���������� "����� ��������" - timeDuration
        if (start)
        {
            if (timeRotate < timeDuration) 
            {
                timeRotate += Time.deltaTime;
            }
            if (timeRotate >= timeDuration)
            {               
                timeRotate = 0.0f;
                end = true; // ���������� "����������� �� ������"
                start = false;
            }          
        }
        // ���������� �� ������
        if (end)
        {
            // ������������ � ��������� �������
            Gun_Rot.transform.localRotation = Quaternion.Lerp(Gun_Rot.transform.localRotation, rotationOriginal, Time.deltaTime / timeReturn);
            
            turn.x = Gun_Rot.transform.localRotation.y; // ����� ��������� ����
            turn.y = Gun_Rot.transform.localRotation.z; // ����� ��������� ����

            if (Gun_Rot.transform.localRotation == rotationOriginal)
            {
                end = false;
            }
        }
    }
}
