using UnityEngine;

public class MoveHorizontalPlatform : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento de la plataforma
    public float distance = 5f; // Distancia máxima que la plataforma se moverá desde su posición inicial
    private Vector3 startPosition; // Posición inicial de la plataforma
    private bool movingLeft = true; // Dirección del movimiento
    private CaptainMovement player;

    void Start()
    {
        // Guardar la posición inicial de la plataforma
        startPosition = transform.position;
       player=GameObject.Find("Captain").GetComponent<CaptainMovement>();

    }

    void Update()
    {
        // Calcular el movimiento
        float movement = speed * Time.deltaTime;

        if (movingLeft)
        {
            // Mover la plataforma hacia adelante (eje Z positivo)
            transform.Translate(Vector3.right * movement);

            // Si la plataforma alcanza la distancia máxima, cambiar de dirección
            if (transform.position.x >= startPosition.x + distance)
            {
                movingLeft = false;
            }
        }
        else
        {
            // Mover la plataforma hacia atrás (eje Z negativo)
            transform.Translate(Vector3.left * movement);

            // Si la plataforma alcanza la distancia máxima, cambiar de dirección
            if (transform.position.x <= startPosition.x - distance)
            {
                movingLeft = true;
            }
        }
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
