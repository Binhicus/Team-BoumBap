using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 newPos;

    [SerializeField]
    Transform target;

    [SerializeField]
    float moveSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newPos = Vector3.Lerp(transform.position, target.position, Time.deltaTime * moveSpeed);
        transform.position = newPos;
    }
}
