using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurret : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 direction;
    private Rigidbody turretRigidBody;
    public float rotateSpeed = 100f;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        turretRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //rotate1();
            rotate3();
        }
       
    }

    void rotate1()
    {
        //Get mouse position
        Vector3 mousePos = Input.mousePosition;
        
        //Adjust mouse z position
        mousePos.z = cam.transform.position.y - transform.position.y;

        //Get a world position for the mouse
        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mousePos);
        
        //Get the angle to rotate and rotate
        float angle = -Mathf.Atan2(transform.position.z - mouseWorldPos.z, transform.position.x - mouseWorldPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), rotateSpeed * Time.deltaTime);
    }
    void rotate2()
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void rotate3()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            if(transform.localEulerAngles.y >= 80 && transform.localEulerAngles.y <= 280)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                // Smoothly rotate towards the target point.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
                
                if(transform.localEulerAngles.y > 280)
                {
                    transform.localEulerAngles = new Vector3(transform.eulerAngles.x,
                                                             280,
                                                             transform.eulerAngles.z
                                                             );
                }
                else if (transform.localEulerAngles.y < 80 )
                {
                    transform.localEulerAngles = new Vector3(transform.eulerAngles.x,
                                                             80,
                                                             transform.eulerAngles.z
                                                             );
                }
            }
            
        }
    }
}
