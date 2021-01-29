using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private bool isChasing = false;

    [SerializeField]
    private float pace = 3;

    private Animator anim;
    private bool attacking;

    [SerializeField]
    private GameObject leftFist;

    [SerializeField]
    private GameObject rightFist;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChasing == true)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * pace * Time.deltaTime;
        }
        /*float dist = Vector3.Distance(transform.position, player.transform.position);       
        if( dist < 10)
            {
            isChasing = false;
            }
        */
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Awareness")
        {
            isChasing = true;
            anim.SetBool("chasing", true);
            //Debug.Log("collision");
        }
        if (other.gameObject.tag == "HitMe")
        {
            attacking = true;
            int randomNumber = Random.Range(1, 2);
            anim.SetBool("Attack", true);
            anim.SetInteger("atk1", randomNumber);
            player.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
            
        }
        if (other.gameObject.tag == "Attack")
        {
            isChasing = false;
            leftFist.SetActive(false);
            rightFist.SetActive(false);
            anim.SetBool("dancing", true);
            GetComponent<Collider>().enabled = false;
            
            //Debug.Log("on court pas dans les couloirs");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Awareness")
        {
            isChasing = false;
            anim.SetBool("chasing", false);
            anim.SetBool("Attack", false);
        }
        if(other.gameObject.tag == "HitMe")
        {
            attacking = false;
        }
    }

    void Heckle()
    {
        if(attacking == true)
        {
            leftFist.SetActive(true);
            rightFist.SetActive(true);
        }

        if(attacking == false)
        {
            leftFist.SetActive(false);
            rightFist.SetActive(false);
        }
    }
}
