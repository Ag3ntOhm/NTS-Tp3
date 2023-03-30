using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Weapon : MonoBehaviour
{
    private bool ShotActive;

    private GameObject shotgun;

    private GameObject pistol;
    // Start is called before the first frame update
    void Start()
    {
        ShotActive = true;
        shotgun = GameObject.Find("Shotgun");
        pistol = GameObject.Find("Beretta Pistol Variant");
        shotgun.SetActive(true);
        pistol.SetActive(false);
    }

    // Update is called once per frame
    public void ChangeWeapon()
    {
        if (ShotActive)
        {
            ShotActive = false;
            shotgun.SetActive(false);
            pistol.SetActive(true);
        }
        else
        {
            ShotActive = true;
            shotgun.SetActive(true);
            pistol.SetActive(false);
        }
    }
    
}
