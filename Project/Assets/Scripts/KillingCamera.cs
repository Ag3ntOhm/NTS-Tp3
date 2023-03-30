using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class KillingCamera : MonoBehaviour
{
    public GameObject bloodEffect;
    private Vector2 touchpos;
    private RaycastHit hit;
    private Camera cam;
    public Text text;
    public int score;
    public Text Pmun;
    public int PMun;
    public Text Smun;
    public int SMun;
    public ParticleSystem muzzleEffect;

    // Start is called before the first frame update
    void Start()
    {
      cam = GetComponent<Camera>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount <= 0)
            return;

        Vector2 centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = cam.ScreenPointToRay(centerScreen);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObj = hit.collider.gameObject;
            if (hitObj.CompareTag("RedEnemy")) {
                var clone = Instantiate(bloodEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                score += 10;
                text.text = "Score :" + score;
                //Instantiate(muzzleEffect, new Vector3(-5, 0, 0), Quaternion.identity);
                //hitObj.GetComponent<MushroomScript>().TakeImpact();
                Destroy(hitObj);
            }
            //if (hitObj.CompareTag("BlackEnemy")) {
            //    var clone = Instantiate(bloodEffect, hitObj.transform.position, Quaternion.identity);
            //    clone.transform.localScale = hitObj.transform.localScale;
            //    score += 100;
            //    text.text = "Score :" + score;
            //    Destroy(hitObj);
            //}

            //if (hitObj.CompareTag("PMun"))
            //{
            //    PMun += 1;
            //    Pmun.text = "P Munition" + PMun;
            //    Destroy(hitObj);
            //}
            //if (hitObj.CompareTag("SMun"))
            //{
            //    SMun += 1;
            //    Smun.text = "S Munition" + SMun;
            //    Destroy(hitObj);
            //}
        }
    }
}
