using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{   

    private Rigidbody2D cannonBallRb;
   // private Collider2D collider;
    [SerializeField] float shootForce;

    void Awake()
    {
        cannonBallRb= GetComponent<Rigidbody2D>();
        
       // collider=GetComponent<Collider2D>();
    }


    void Update()
    {

    }

    void OnEnable()
    {
      cannonBallRb.AddRelativeForceX(shootForce,ForceMode2D.Impulse);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ShipEnemy"))
          {
            gameObject.SetActive(false);
          } 
    }


}
