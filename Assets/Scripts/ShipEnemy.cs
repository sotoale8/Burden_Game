using UnityEngine;

public class ShipEnemy : MonoBehaviour
{   
     private Animator sailAnimator;
    private bool isWind;
    private int life;
    [SerializeField] Vector3 movement;
    [SerializeField] float aproachSpeed;
    GameObject captainShip; 

    public Vector3 acercamiento;
    
    void Start()
    {
        life=3;
        captainShip=GameObject.Find("Captain Ship");
        sailAnimator= transform.GetChild(4).GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        isWind=true;
        sailAnimator.SetBool("isWind",isWind);
        
        movement.x=(captainShip.transform.position-transform.position).normalized.x* aproachSpeed;
        movement.y=0.7f*Mathf.Cos(1.0f+Time.time/0.7f);
        movement.z=0f;
        transform.Translate(movement*Time.deltaTime);
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cannonball"))
            {
                life--;
            }
         if(life==0)
            {
                Destroy(gameObject);
            }  
    }
}
