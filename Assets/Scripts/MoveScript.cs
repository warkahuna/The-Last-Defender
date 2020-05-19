using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public GameObject otherObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        otherObject.transform.position = transform.TransformPoint(0, 2, 1);
    }
}
