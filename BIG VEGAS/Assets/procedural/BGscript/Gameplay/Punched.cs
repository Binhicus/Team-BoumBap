using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punched : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = GameManager.Instance.lastCheckPoint.position;
        }
    }
}
