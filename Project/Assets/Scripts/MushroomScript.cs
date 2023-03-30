using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    public Rigidbody rb;
    public int explosionForce;
    GameObject hat;

    private bool Detatched = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }



    public void TakeImpact(Vector3 shooterPos)
    {
        Vector3 pos = transform.position;
        Vector3 explositionPos = pos + (shooterPos - pos) / 10;
        rb.AddExplosionForce(explosionForce, explositionPos, 1f);
        if (!Detatched)
        {
            hat.transform.DetachChildren();
            Detatched = true;
        }

        //Destroy(gameObject);
    }
}
