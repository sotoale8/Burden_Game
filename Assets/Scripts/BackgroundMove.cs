using UnityEngine;

public class BackgroundMove : MonoBehaviour
{   
    [SerializeField] float speed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left) ;   

        if(transform.position.x<-159f)
            {
                transform.position=new Vector2(-7.7f,0.67f);
            }
    }
}
