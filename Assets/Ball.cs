using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D ballrib;
    [SerializeField] float force;
    void Start()
    {
        ballrib= GetComponent<Rigidbody2D>();   
        ballrib.AddRelativeForce(force*transform.right);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
