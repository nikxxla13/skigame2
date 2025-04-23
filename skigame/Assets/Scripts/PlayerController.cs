using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private KeyCode leftInput, rightInput;
    [SerializeField] private float acceleration = 100, turnSpeed = 100,minSpeed =0,  maxSpeed = 500;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform groundTransform;
    [SerializeField] private float speed = 0, minAcceleration = -200, maxAcceleration = 500;
    [SerializeField] private TakeDamage takeDamage;
    
    
    private Rigidbody rb;
    private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        bool isGrounded = Physics.Linecast(transform.position, groundTransform.position, groundLayers);

        if (isGrounded && !takeDamage.isHurt)
        {
            if (Input.GetKey(leftInput) && transform.eulerAngles.y <269)
            {
                transform.Rotate(new Vector3(0, turnSpeed*Time.deltaTime,0),Space.Self);
            }

            if (Input.GetKey(rightInput) && transform.eulerAngles.y > 91)
            {
                transform.Rotate(new Vector3(0, -turnSpeed*Time.deltaTime,0),Space.Self);
            }
        }
    }
    private void FixedUpdate()
    {
        if (takeDamage.isHurt)
            return;
        float angle = Mathf.Abs(transform.eulerAngles.y - 180);
        acceleration = Remap(0, 90, maxAcceleration, minAcceleration, angle);
        speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
        animator.SetFloat("playerSpeed", speed);
        Vector3 velocity = transform.forward * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    private float Remap(float oldMin, float oldMax, float newMin, float newMax, float oldValue)
    {
        float oldRange = (oldMax - oldMin);
        float newRange = (newMax - newMin);
        float newValue = (((oldValue - oldMin) / oldRange) * newRange + newMin);
        return newValue;
    }
 
}
