using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3f;

    private float countdown;

    public float radius = 3;

    public float explosionForce = 70;

    bool exploded = false;

    public GameObject explosionEffect;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0 && exploded == false) 
        {

            Explosive();

            exploded = true;
          
            
        }
    }

    private void Explosive()
    {

        Instantiate(explosionEffect,transform.position,transform.rotation);

        //Pilla los elementos dentro del radio de la granada
        Collider[] collider = Physics.OverlapSphere(transform.position, radius);

        //Y si TIENE RIGIDBODY, destruira la grnada y le aplciara la fuerza de explosion a los rigidbodys, asi empujandoles
        foreach (var rangeObjects in collider)
        {
            Rigidbody rb = rangeObjects.GetComponent <Rigidbody>();

            if (rb!= null ) 
            {
                rb.AddExplosionForce(explosionForce * 10, transform.position, radius );
            }
        }

        Destroy(gameObject);

    }
}
