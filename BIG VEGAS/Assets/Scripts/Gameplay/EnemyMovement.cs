using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private bool isChasing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isChasing == true)
        {
            transform.LookAt(player.transform);
            transform.position += transform.forward * 1f * Time.deltaTime;
        }
        if(isChasing == false)
        {
            transform.LookAt(player.transform);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Awareness")
        {
            isChasing = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isChasing = false;
        }
    }
}
