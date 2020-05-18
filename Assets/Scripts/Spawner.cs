using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public GameObject bossSpawnee;  
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public float spawnedNumber;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnedNumber == 0)
        {
            stopSpawning = false;
            Invoke("spawnBossObject", spawnDelay);
            spawnedNumber = -1;
        }
        
    }


    public void spawnObject()
    {
        if(spawnedNumber > 0)
        {
            spawnedNumber--;
            Instantiate(spawnee, transform.position, transform.rotation);
            if (stopSpawning)
            {
                CancelInvoke("spawnObject");
            }
        }

    }

    public void spawnBossObject()
    {
        Instantiate(bossSpawnee, transform.position, transform.rotation);
    }
}
