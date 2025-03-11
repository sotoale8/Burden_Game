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



    void Start()
    {
       sailAnimator= transform.GetChild(4).GetComponentInChildren<Animator>();
       incialPos= transform.position;
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

        Vector2 vectorDirector= posicionfinal-posicioninicial;
       // MathF.Acos(Vector2.right,vectorDirector.normalized);
           
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Captain"))
            {
                collision.transform.SetParent(this.transform);
            }  
    }

    void OnCollisionExit2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Captain"))
            {   
                StartCoroutine(ChangeParent(collision.gameObject.transform));
            }  
    }

    IEnumerator ChangeParent(Transform captain)
    {
        yield return null;
        captain.transform.SetParent(null);
    }
}