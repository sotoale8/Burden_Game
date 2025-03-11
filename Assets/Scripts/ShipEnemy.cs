using UnityEngine;


public class ShipEnemy : MonoBehaviour
{   
     private Animator sailAnimator;
    private int life;
    [SerializeField] Vector3 movement;
    [SerializeField] float aproachSpeed;
    public LayerMask playerMask;
    GameObject captainShip; 
    public GameObject burdenAnchor; 

    [SerializeField] Transform anchor;
    public Vector3 acercamiento;
    [SerializeField]private bool sinkingEnable=false;
    [SerializeField] private float sinkingVelocity;
     CaptainMovement player;
    
    void Start()
    {
        life=3;
        captainShip=GameObject.Find("Captain Ship");
        
        
        sailAnimator= transform.GetChild(1).GetComponentInChildren<Animator>();
        sailAnimator.SetBool("isWind",true);
        player= GameObject.Find("Captain").GetComponent<CaptainMovement>(); 

    }

    // Update is called once per frame
    void Update()
    {   
        
        
         if (!sinkingEnable)
        {
            movement.y=0.7f*Mathf.Cos(1.0f+Time.time/0.7f);
        }
        movement.z=0f;
        transform.Translate(movement*Time.deltaTime);
        
        
   
        CheckCaptain();
        if(CheckCaptain()!=null && Input.GetKeyDown(KeyCode.E)) 
        {
              transform.GetChild(2).gameObject.SetActive(true);
              burdenAnchor.SetActive(false);
              
        if(!burdenAnchor.activeSelf)
            {
            sinkingEnable=true;
            movement.y=-sinkingVelocity;
            sailAnimator.SetBool("isWind",false);
            }

        player.RestoreSpeedAndJump(5 , 500);

       }
    


    }

    private Collider2D CheckCaptain()
    {
     return Physics2D.OverlapCircle(anchor.position,1.5f,playerMask);
       
    }

   

}
