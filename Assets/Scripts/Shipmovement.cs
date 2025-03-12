using System.Collections;
using UnityEngine;

public class Shipmovement : MonoBehaviour
{   
    private Animator sailAnimator;
    private bool isWind;
   
    public float oscSpeed;
    public float speed;
    public float h;
    [SerializeField] Vector3 movement;
    [SerializeField] Vector3 incialPos;
    [SerializeField] Vector2 posicioninicial;
    [SerializeField] Vector2 posicionfinal;
    private CaptainMovement player;


    void Start()
    {
       sailAnimator= transform.GetChild(4).GetComponentInChildren<Animator>();
       incialPos= transform.position;
        player=GameObject.Find("Captain").GetComponent<CaptainMovement>();
    }

    // Update is called once per frame
    void Update()
    {   
        isWind=true;
        sailAnimator.SetBool("isWind",isWind);
        //movement.x=Time./oscSpeed;
        movement.x=0;

        movement.y=h*Mathf.Cos(Time.time/speed);
        movement.z=0f;
        posicioninicial=transform.position;
        transform.Translate(movement*Time.deltaTime);
        posicionfinal=transform.position;

    
           
    }


     private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jugador colisiona con la plataforma y no está cayendo ni regresando
        if (collision.gameObject.CompareTag("Captain"))
        {
           player.onPlatform=true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Si el jugador deja de colisionar con la plataforma y esta está cayendo
        if (collision.gameObject.CompareTag("Captain"))
        {
             player.onPlatform=false;
            
        }
    }
}
