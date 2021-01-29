using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTarget : MonoBehaviour
{
    [SerializeField]
    Transform bigVegas;

    [SerializeField]
    float offset = 4f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 uphill = new Vector3(0, offset, 0);
        transform.position = bigVegas.position + uphill;
    }
}
