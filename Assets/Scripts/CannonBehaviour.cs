using UnityEngine;


public class CannonBehaviour : MonoBehaviour
{   
    private Animator animator;
    public GameObject cannoBallPrefab;
    private Transform spawnPoint;
    [SerializeField] float rotationAngle;
    public LayerMask playerMask;

    public float actualAngle;

     void Start()
    {
        animator= GetComponent<Animator>();
        spawnPoint=transform.GetChild(0).GetComponent<Transform>();
       
    }

   
    void Update()
    {
        CheckCaptain();
        if(CheckCaptain()!=null) 
            {
                Fire();
                Rotation();
            }


    }

    private Collider2D CheckCaptain()
    {
     return Physics2D.OverlapCircle(transform.position,1.5f,playerMask);
       
    }

    private void Rotation()
    {   
        actualAngle= transform.rotation.eulerAngles.z;
        if(actualAngle>180)
            {
                actualAngle-=360f;
            } 
       if(Input.GetKeyDown(KeyCode.I)&& actualAngle>-45f)
        {
            gameObject.transform.Rotate(Vector3.forward*-rotationAngle);
        ;
            
        }
        else if (Input.GetKeyDown(KeyCode.K)&&actualAngle<-2) 
        {
            gameObject.transform.Rotate(Vector3.forward*rotationAngle);
        }         
    }

    private void Fire()
    {   
       if( Input.GetKeyDown(KeyCode.F))
       {
        //Instantiate(cannoBallPrefab,spawnPoint.position,spawnPoint.rotation);

        GameObject ball = BallPool.Instance.UseBall1();
        ball.transform.SetPositionAndRotation(spawnPoint.position,spawnPoint.rotation);
        ball.SetActive(true);
        animator.SetTrigger("fire");
       }
   

    }

    void OnDrawGizmos()
    {
        Gizmos.color= Color.blue;
        Gizmos.DrawWireSphere(transform.position,1.5f);
    }

}
