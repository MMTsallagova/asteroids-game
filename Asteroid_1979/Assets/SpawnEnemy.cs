using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
   // public GameObject Enemy;
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    public float SpawnTime;
    public float Timer = 0.0f;

    void Start()
    {
        SpawnTime = Random.Range(3.0f, 7.0f);

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (SpawnTime < Timer)
        {
            var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            Instantiate(prefab, transform.position, Quaternion.identity);


           // Instantiate(Enemy, transform.position, Quaternion.identity);
            SpawnTime = Random.Range(4.0f, 7.0f);
            Timer = 0.0f;
        }
    }
}
