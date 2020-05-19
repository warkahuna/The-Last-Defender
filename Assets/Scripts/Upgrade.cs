using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    private float rotationSpeed;
    public static float health =3;
    public float ammunation;
    public float reloadSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void damagedHp(float damage)
    {
        if (health > 0)
        { 
            health -= damage;
        Debug.Log("heal--");
        }
        else
            Debug.Log("lost");
    }

}
