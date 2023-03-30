using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    public Rigidbody rb;
    public int explosionForce;
    public GameObject hat;

    private bool Detatched = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }



    public void TakeImpact()
    {
        Vector3 pos = transform.position;
        Vector3 explositionPos = pos + (new Vector3(0,0,0) - pos) / 10;
        rb.AddExplosionForce(explosionForce, explositionPos, 1f);
        rb.isKinematic = false;
        hat.GetComponent<Rigidbody>().isKinematic = false;

        if (!Detatched)
        {
            hat.transform.DetachChildren();
            Detatched = true;
        }
        
        //Destroy(gameObject);
    }
}
