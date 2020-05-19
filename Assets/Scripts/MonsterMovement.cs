using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class MonsterMovement : MonoBehaviour
{
    public Transform Player;
    public float MoveSpeed = 1;
    public float MaxDist = 10;
    public float MinDist = 5;
    private Animator anim;
    private bool lookingAt = true;

    public Camera cam;
    public NavMeshAgent agent;

    public float hp;
    public float maxHp;
    public GameObject healthBarUi;
    public Slider slider;

    public float damage;
    public GameObject killCounter;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = Camera.main;

        hp = maxHp;
        slider.value = calculateHealth();
        damage = GameObject.FindGameObjectWithTag("Gun").GetComponent<Upgrade>().damage;
        killCounter = GameObject.FindGameObjectWithTag("KillCounter");
    }

    // Update is called once per frame
    void Update()
    {
       
        /*if (Input.GetKeyDown("z"))
        {
            start = true;
        }
        if(start)
        {
            startWave();
        }*/
        slider.value = calculateHealth();

        if (hp < maxHp)
        {
            healthBarUi.SetActive(true);
        }
        if (hp <= 0)
        {
            anim.ResetTrigger("isRunning");
            anim.SetTrigger("GetHitToDead");
            //Destroy(gameObject);
            Invoke("killed", 1f);
        }
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if(hp>=0f)
        {
            startWave2();
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
        if (lookingAt)
        {
            transform.LookAt(Player);
        }

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            StartCoroutine(WaitForAnimationToPlay());


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {

                /*anim.SetTrigger("isAttacking");
                anim.ResetTrigger("isRunning");*/
                //lookingAt = false;
                //transform.position += Vector3.left * MoveSpeed*2 * Time.deltaTime;
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
           
                hp -= damage;
           
            
            //anim.ResetTrigger("isRunning");
           // anim.SetTrigger("RunningToGetHit");
            //anim.SetTrigger("GetHitToRunning");
        }
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Upgrade.damagedHp(1); //1 represents the health lowerd from player
        }
        if (other.tag == "Gun")
        {
            //transform.Rotate(new Vector3(90, 0, 0), 90);
        }
    }

    public void startWave2()
    {
        transform.LookAt(Player.position);
       Ray ray = cam.ScreenPointToRay(Player.position);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            StartCoroutine(WaitForAnimationToPlay());


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {

                /*anim.SetTrigger("isAttacking");
                anim.ResetTrigger("isRunning");*/
                //lookingAt = false;
                //transform.position += Vector3.left * MoveSpeed*2 * Time.deltaTime;
                
            }
        }

    }


   public float calculateHealth()
    {

        return hp/maxHp;
    }

    public void killed()
    {
        Destroy(gameObject);
        KillCounter.addKills(1);
    }
}
