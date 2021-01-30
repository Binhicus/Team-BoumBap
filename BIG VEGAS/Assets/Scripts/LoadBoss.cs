using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBoss : MonoBehaviour
{
    [SerializeField]
    private string sceneBoss;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            BossFight();
        }
    }

    void BossFight()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBoss);
    }
}
