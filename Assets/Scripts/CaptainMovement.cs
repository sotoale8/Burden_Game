using UnityEngine;

public class CaptainMovement : MonoBehaviour
{   

    private Rigidbody2D captainRb;
    private Animator animator;
    private Transform captainTransform;
    private Vector3 captainScale;

    private float currentMoveSpeed;
    private float   currentJumpForce; 
    private float horizontal;
    private float vertical;
    public bool isGrounded;
    public bool running;
    public bool jumped;
    [SerializeField] float runMovementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Transform checkGroundPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        captainRb= GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        captainTransform=GetComponent<Transform>();
        captainScale= transform.localScale;
        currentMoveSpeed=runMovementSpeed;
        currentJumpForce=jumpForce;

    }

    // Update is called once per frame
    void Update()
    {
        horizontal= Input.GetAxis("Horizontal");
        vertical= Input.GetAxis("Vertical");
        if (horizontal>0)
            {
                transform.localScale=new Vector3(captainScale.x,captainScale.y,captainScale.z);  
            }
        else if (horizontal<0)
            {
                transform.localScale=new Vector3(-captainScale.x,captainScale.y,captainScale.z);    
                
            }
        
        CheckGround();       
    }

    void FixedUpdate()
    {
        running = horizontal!=0;      
        animator.SetBool("running",running && isGrounded);
        captainRb.linearVelocity=new Vector2(horizontal*currentMoveSpeed,captainRb.linearVelocityY);
        Jump();


    }   
    private void Jump()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            captainRb.AddForce(Vector2.up*currentJumpForce,ForceMode2D.Impulse);    
            jumped=true; 
            animator.SetBool("jumped",jumped);
             
        }

    }

    private void CheckGround()
    {
        isGrounded=Physics2D.Raycast(checkGroundPos.position,Vector2.down,0.02f);
        jumped=!isGrounded;
        animator.SetBool("jumped",jumped);
        animator.SetBool("isGrounded",isGrounded);
    }

    public void ReduceSpeedAndJump(float speedReduction, float jumpReduction)
    {
        currentMoveSpeed = speedReduction;
        currentJumpForce = jumpReduction;
    }

    // Método para restaurar velocidad y salto
    public void RestoreSpeedAndJump(float speedRestore, float jumpRestore)
    {
        currentMoveSpeed= speedRestore;
        currentJumpForce= jumpRestore;
    }

}
