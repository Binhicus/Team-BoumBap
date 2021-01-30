using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LegacyInput))]
public class TopDownCC : MonoBehaviour
{
    private LegacyInput input;

    [SerializeField]
    private bool RotateTowardMouse;

    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private Camera Camera;

    [SerializeField]
    GameObject _chant;

    private bool isSinging = false;

    private Animator anim;
    private Vector3 movement;
    private float h;
    private float v;

    [SerializeField]
    private AudioSource song1;
    //private Vector3 movementVector;

    private void Awake()
    {
        input = GetComponent<LegacyInput>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Animate();

        Vector3 targetVector = new Vector3(input.InputVector.x, 0, input.InputVector.y);
        Vector3 movementVector = MoveTowardTarget(targetVector);

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //movement = (h + v);
        
        //transform.InverseTransformDirection()

        if (!RotateTowardMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (RotateTowardMouse)
        {
            RotateFromMouseVector();
        }
        if(Input.GetButton("Fire1"))
        {
            song1.mute = false;
            isSinging = true;
            Sing();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isSinging = false;
            song1.mute = true;
            Sing();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY |RigidbodyConstraints.FreezeRotationX |RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        }

        //Debug.Log();
    }

    void GetInput()
    {
        Vector3 horizontal = h * Camera.main.transform.right;
        Vector3 vertical = v * Camera.main.transform.up;

        horizontal.y = 0;
        vertical.y = 0;

        movement = (horizontal + vertical);

    }

    void Animate()
    {
        Vector3 targetVector = new Vector3(input.InputVector.x, 0, input.InputVector.y);
        Vector3 movementVector = MoveTowardTarget(targetVector);
        Vector3 localMove = transform.InverseTransformDirection(targetVector);
        anim.SetFloat("forward", localMove.z);
        anim.SetFloat("sideways", localMove.x);

        //Debug.Log(localMove);
    }

    void RotateFromMouseVector()
    {
        Ray ray = Camera.ScreenPointToRay(input.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        float speed = MovementSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, Camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        Vector3 targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }

    void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed);
    }

    void Sing()
    {
        if (isSinging == true)
        {
            _chant.SetActive(true);
        }
        if (isSinging == false)
        {
            _chant.SetActive(false);
        }
        
    }
}
