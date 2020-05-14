using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 2f);
    }

    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
        CancelInvoke();
    }
    private void hideBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
           //Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            Debug.Log("hello");
            //gameObject.SetActive(false);
        }
    }*/


}
