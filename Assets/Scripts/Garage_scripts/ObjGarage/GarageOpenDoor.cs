using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GarageOpenDoor : MonoBehaviour
{
    public GameObject leftDoor;

    public bool openActive;
    public Vector3 targetPoint = new Vector3(0, -4.69f, 0);
    public float speed;
    public ManagerCamera manCamera;

    void Update()
    {
        if(openActive)
        {
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, targetPoint, speed * Time.deltaTime);
        }
        else
        {
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, new Vector3(0,0,0), speed * Time.deltaTime);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openActive = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openActive = false;
            manCamera.Invert = false;
            manCamera.edit = false;
            manCamera.backEdit.SetActive(false);
        }
    }
}
