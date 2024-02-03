using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    [Header("Зацепка")]
    public GameObject anchor;
    public void Start()
    {
        anchor = transform.gameObject;
    }
}
