using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //float bulletSpeed = 1100;
    float bulletSpeed = 500;
    public GameObject bullet;

    //AudioSource bulletAudio;

    List<GameObject> bulletList;
    // Use this for initialization
    void Start()
    {
        bulletList = new List<GameObject>();
        for(int i=0; i<10; i++)
        {
            GameObject objBullet = Instantiate(bullet) as GameObject;
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
        //bulletAudio = GetComponent<AudioSource>();

    }

    void Fire()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                
                Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();
                tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
                break;
            }
        }
        //Shoot
            /*GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
            tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
            Destroy(tempBullet, 0.5f);*/


            //Play Audio
           // bulletAudio.Play();

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }
}
