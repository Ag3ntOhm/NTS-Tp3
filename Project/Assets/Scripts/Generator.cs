using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

    private List<GameObject> _placedobject;

    [SerializeField] public GameObject[] prefabs;
    [SerializeField] public GameObject[] mun;
    public int time = 5;
    public int count;
    [SerializeField] private ARPlaneManager ArPlaneManager;

    void Awake()
    {
        ArPlaneManager = GetComponent<ARPlaneManager>();
        ArPlaneManager.planesChanged += PlaneChanged;
    }

    private void Update()
    {
        count++;
        if (count == time * 30)
        {
            ArPlaneManager.planesChanged += PlaneChanged;
            count = 0;
        }
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        

        if (args.added != null)
        {
            var arPlane = args.added[0];
            while (_placedobject.Count < 4)
            {
                var index = Random.Range(0, prefabs.Length);
                var random1 = Random.Range(-arPlane.size.x, arPlane.size.x);
                var random2 = Random.Range(-arPlane.size.y, arPlane.size.y);
                _placedobject.Add(Instantiate(prefabs[index],
                    arPlane.transform.position + new Vector3(random1, 0, random2),
                    Quaternion.identity));
            }
            var i = Random.Range(0, mun.Length);
            var r1 = Random.Range(-arPlane.size.x, arPlane.size.x);
            var r2 = Random.Range(-arPlane.size.y, arPlane.size.y);
            Instantiate(mun[i], arPlane.transform.position + new Vector3(r1, 0, r2),
                Quaternion.identity);
        }


    }
}