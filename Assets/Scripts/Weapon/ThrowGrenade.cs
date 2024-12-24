using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{

    public float throwForce = 500f;

    public GameObject grenadePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            Throw();
        }
    }
    //A la granada creada, se le aplica una fuerza hacia adelante multiplicada por la fuerza del "throwForce"
    private void Throw()
    {
        GameObject newGrenade = Instantiate(grenadePrefab,transform.position,transform.rotation);

        newGrenade.GetComponent <Rigidbody>().AddForce(transform.forward * throwForce) ;
    }
}
