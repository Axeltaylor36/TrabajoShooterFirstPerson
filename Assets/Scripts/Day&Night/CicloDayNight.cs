using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDayNight : MonoBehaviour
{



    [SerializeField] float rotationSky = 10f;

    void Update()
    {
        transform.Rotate(rotationSky * Time.deltaTime, 0, 0);
    }
}
