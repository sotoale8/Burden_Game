using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1f; // Tiempo antes de que la plataforma comience a caer
    public float fallSpeed = 5f; // Velocidad a la que la plataforma cae
    public float returnSpeed = 5f; // Velocidad a la que la plataforma regresa a su posición inicial

    private Vector3 startPosition; // Posición inicial de la plataforma
    private bool isFalling = false;
    private bool isReturning = false;

    void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial
    }

    void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jugador colisiona con la plataforma y no está cayendo ni regresando
        if (collision.gameObject.CompareTag("Captain"))
        {
            Debug.Log("entraron en colision");
            collision.collider.gameObject.transform.SetParent(transform);
            isFalling = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Si el jugador deja de colisionar con la plataforma y esta está cayendo
        if (collision.gameObject.CompareTag("Captain"))
        {
            Debug.Log("Salieron de colision");
             collision.collider.gameObject.transform.SetParent(null);
            isFalling = false;
        }
    }
   
    
}