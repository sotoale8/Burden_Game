using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public float moveDistance; 
    public float moveSpeed; 

    private Vector3 startPosition; 
    private bool movingUp = true; 
    private CaptainMovement player;

    void Start()
    {
        startPosition = transform.position; 
        player=GameObject.Find("Captain").GetComponent<CaptainMovement>();
    }

    void Update()
    {
        
        float newY = transform.position.y + (movingUp ? moveSpeed : -moveSpeed) * Time.deltaTime;

        // Si la plataforma supera la distancia máxima, cambia de dirección
        if (newY > startPosition.y + moveDistance)
        {
            newY = startPosition.y + moveDistance;
            movingUp = false;
        }
        else if (newY < startPosition.y)
        {
            newY = startPosition.y;
            movingUp = true;
        }

        // Aplica el nuevo valor de Y al transform
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jugador deja de colisionar con la plataforma y esta está cayendo
        if (collision.gameObject.CompareTag("Captain"))
        {
            Debug.Log("Captain in");
            collision.collider.gameObject.transform.SetParent(transform);
            player.onPlatform=true;
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Si el jugador deja de colisionar con la plataforma y esta está cayendo
        if (collision.gameObject.CompareTag("Captain"))
        {
            Debug.Log("Captain out");
            collision.collider.gameObject.transform.SetParent(null);
            player.onPlatform=false;
            
        }
    }
}