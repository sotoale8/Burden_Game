using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1f; 
    public float respawnSpeed = 2f;

    private Vector3 startPosition; 
    private Rigidbody2D rb;
    private bool isFalling = false;
    private bool isResetting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // Guardamos el dato de la posicion inicial
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Captain") && !isFalling && !isResetting)
        {
            collision.gameObject.transform.SetParent(transform);
            Invoke("StartFalling", fallDelay); // Inicia la caída después de un retraso
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Captain") && isFalling)
        {   
            collision.gameObject.transform.SetParent(null);
            ResetPlatform(); // Reinicia la plataforma
        }
    }

    private void StartFalling()
    {
        isFalling = true;
        rb.bodyType = RigidbodyType2D.Dynamic; // Qutamos el kinematico para que active la gravedad
    }

    private void ResetPlatform()
    {
        isFalling = false;
        isResetting = true;
        rb.linearVelocity = Vector2.zero; // Detiene el movimiento
        rb.bodyType = RigidbodyType2D.Kinematic; // Desactiva la gravedad

        StartCoroutine(ReturnToStartPosition()); // Inicia el movimiento gradual
    }

    private IEnumerator ReturnToStartPosition()
    {
        while (Vector3.Distance(transform.position, startPosition) > 0.1f)
        {
            // Mueve la plataforma gradualmente hacia su posición inicial
            transform.position = Vector3.MoveTowards(transform.position, startPosition, respawnSpeed * Time.deltaTime);
            yield return null; // Espera al siguiente frame
        }

        // Asegura que la plataforma esté exactamente en la posición inicial
        transform.position = startPosition;
        isResetting = false;
    }
}