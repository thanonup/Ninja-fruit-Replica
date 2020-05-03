using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuritSpawner : MonoBehaviour
{
    public GameObject[] ObPrefeb;
    public Transform[] spawnPoint;
    public List<GameObject> newObstacles;

    public float minDelay = .1f;
    public float maxDelay = 1f;

    [HideInInspector]
    public bool CheckSpawn = true;

    public static FuritSpawner instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (CheckSpawn)
        {

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            if (CheckSpawn)
            {
                int spawnIndex = Random.Range(0, spawnPoint.Length);
                Transform spawnPoint1 = spawnPoint[spawnIndex];

                int SpawnIndexObs = 0;
                bool SpawnOn = false;
                if (Random.value <= 0.8)
                {
                    SpawnIndexObs = 0;
                    SpawnOn = true;
                    print("Green");
                }
                if (Random.value <= 0.2)
                {
                    SpawnIndexObs = 1;
                    SpawnOn = true;
                    print("Black");
                }
                if (SpawnOn)
                {
                    GameObject spawnFruit = Instantiate(ObPrefeb[SpawnIndexObs], spawnPoint1.position, spawnPoint1.rotation);
                    Destroy(spawnFruit, 5f);
                }
                SpawnOn = false;
            }

            //int spawnIndexOb = Random.Range(0, ObPrefeb.Length);

        }
    }
}
