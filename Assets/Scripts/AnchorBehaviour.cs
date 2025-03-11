using UnityEngine;

public class AnchorBehaviour : MonoBehaviour
{
    Rigidbody2D captainRb;
    CaptainMovement captainMovement;
    [SerializeField] float anchorForce;

        void Start()
    {
        captainRb= GameObject.Find("Captain").GetComponent<Rigidbody2D>();
        captainMovement= GameObject.Find("Captain").GetComponent<CaptainMovement>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (captainMovement.jumped && captainRb.linearVelocityY==0 ) 
        {
            captainRb.AddRelativeForceY(anchorForce,ForceMode2D.Impulse) ; 
            print("entra");  
        }
        
    }
}
