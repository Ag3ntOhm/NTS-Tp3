using System.Threading;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public Transform cam;
    public ARSessionOrigin arSessionOrigin;

    public float spawnRange = 10f;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count == 60)
        {
            SpawnEnemy();
            count = 0;
        }
        count++;
    }

    public void SpawnEnemy()
    {
        var position = cam.transform.position;
        float x = position.x + Random.Range(-spawnRange, spawnRange);
        float y = position.y + Random.Range(-spawnRange, spawnRange);
        float z = position.z + Random.Range(-spawnRange, spawnRange);

        Transform player = arSessionOrigin.camera.transform;
        Vector3 spawnPos = new Vector3(x, y, z);
        Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
        

    }
}