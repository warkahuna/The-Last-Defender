﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void spawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if(stopSpawning)
        {
            CancelInvoke("spawnObject");
        }

    }
}
