using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 1;
    public float MaxDist = 11;
    public float MinDist = 10;
    private Animator anim;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            start = true;
        }
        if(start)
        {
            startWave();
        }
    }

   IEnumerator WaitForAnimationToPlay()
    {
        yield return new WaitForSeconds(1.30f);
        
        anim.ResetTrigger("isWalking");
        anim.SetTrigger("isRunning");
    }

    public void startWave()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            StartCoroutine(WaitForAnimationToPlay());


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                anim.SetTrigger("isAttacking");
                anim.ResetTrigger("isRunning");

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("get hit");
            
            anim.ResetTrigger("isRunning");
            anim.SetTrigger("RunningToGetHit");
            //anim.SetTrigger("GetHitToRunning");
        }
    }
}
