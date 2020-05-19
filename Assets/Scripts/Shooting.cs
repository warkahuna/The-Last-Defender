using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    //float bulletSpeed = 1100;
    float bulletSpeed = 500;
    public GameObject bullet;
    private float ammo =5;
    private float reload;
    private float reloadSpeed = 0.1f;

    AudioSource bulletAudio;

    List<GameObject> bulletList;

    public Text ammoText;
    public GameObject gunBarrel;
    private bool shutDown = false;
    // Use this for initialization
    void Start()
    {
        bulletList = new List<GameObject>();
        for(int i=0; i< ammo; i++)
        {
            GameObject objBullet = Instantiate(bullet) as GameObject;
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
        bulletAudio = GetComponent<AudioSource>();
        ammo = GameObject.FindGameObjectWithTag("Gun").GetComponent<Upgrade>().ammunation;
        reload = ammo;
        reloadSpeed = GameObject.FindGameObjectWithTag("Gun").GetComponent<Upgrade>().reloadSpeed;
        gunBarrel = GameObject.FindGameObjectWithTag("GunBarrel");
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
        ammo--;


        //Shoot
            /*GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
            tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
            Destroy(tempBullet, 0.5f);*/


            //Play Audio
            bulletAudio.Play();

    }


    // Update is called once per frame
    void Update()
    {
        if(ammo<0)
        ammoText.text = "Ammo : " + 0 + " / " + reload;
        else
        ammoText.text = "Ammo : " + ammo + " / " + reload;

        if (Input.GetMouseButtonDown(0))
        {
            CancelInvoke("reloading");
            if (ammo > 0 && (Time.timeScale == 1))
            {
                Fire();
                
            }
           
        }
        if(Input.GetKeyDown("r"))
        {
            
            InvokeRepeating("reloading", 1,reloadSpeed);
        }

        if (ammo == 0)
        {
            ammo = -1;
            shutDown = true;
        }

        if (ammo == -1)
        {
            reloadPos();
        }
       
    }

    public void reloading()
    {
        if (ammo < reload)
        {
            if(ammo == -2)
            {
                ammo+=2;
            }
               
            ammo++;
            if(shutDown)
            {
                shutDown = false;
                gunBarrel.transform.Rotate(-40, 0, 0);

            }
        }
        else
        {
            CancelInvoke("reloading");
        }
        
    }

    public void reloadPos()
    {
        gunBarrel.transform.Rotate(+40, 0, 0);
        ammo = -2;
    }
}
