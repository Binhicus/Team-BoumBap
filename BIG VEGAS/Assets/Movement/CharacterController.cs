using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private PlayerInputActions playerInput;
    private Vector2 movementInput;
    private Camera main;
    

    [SerializeField]
    private GameObject reach;

    [SerializeField]
    private float velocity = 3f;

    [SerializeField]
    private float speed = 10f;


    private Vector3 inputDirection;

    private Vector3 moveVector;
    private Quaternion currentRotation;

    void Awake()
    {
        playerInput = new PlayerInputActions();
        playerInput.Player.Movement.performed += context => movementInput = context.ReadValue<Vector2>();

    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    

    
    void FixedUpdate()
    {
        float h = movementInput.x;
        float v = movementInput.y;

        Vector3 targetInput = new Vector3(h, 0, v);

        inputDirection = Vector3.Lerp(inputDirection, targetInput, Time.deltaTime * 10f);

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 desiredDirection = camForward * inputDirection.z + camRight * inputDirection.x;

        Move(desiredDirection);
        Turn(desiredDirection);
    }

    private void Move(Vector3 desiredDirection)
    {
        moveVector.Set(desiredDirection.x, 0f, desiredDirection.z);
        moveVector = moveVector * speed * Time.deltaTime;
        transform.position += moveVector;
    }

    void Turn(Vector3 desiredDirection)
    {
        if ((desiredDirection.x > 0.1 || desiredDirection.x < -0.1) || (desiredDirection.z > 0.1 || desiredDirection.z < -0.1))
        {
            currentRotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = currentRotation;
        }
        else
            transform.rotation = currentRotation;
    }
}
