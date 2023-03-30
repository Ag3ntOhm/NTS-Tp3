using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public Transform cam;
    public ARSessionOrigin arSessionOrigin;
    private int mushroomNumber;
    public float spawnRange = 10f;
    public GameObject loseText;
    public Text enemyText;
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
        mushroomNumber = GameObject.FindGameObjectsWithTag("RedEnemy").Length;
        enemyText.text = "Enemies (max 100) : " + mushroomNumber.ToString();
        if (mushroomNumber >= 100)
        {
            loseText.SetActive(true);
        }
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