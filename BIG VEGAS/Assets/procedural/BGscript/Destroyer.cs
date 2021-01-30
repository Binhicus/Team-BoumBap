using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Labyrinthe" || other.gameObject.tag == "SpawnPoint")
       {
            Debug.Log("ierffr");
            Destroy(other.gameObject);
       }	
	}
}
