using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingCamera : MonoBehaviour
{
    public GameObject particlesEffect;
    private Vector2 touchpos;
    private RaycastHit hit;
    private Camera cam;

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
            if (hitObj.tag == "Enemy") {
                var clone = Instantiate(particlesEffect, hitObj.transform.position, Quaternion.identity);
                clone.transform.localScale = hitObj.transform.localScale;
                Destroy(hitObj);
            }
        }
    }
}
