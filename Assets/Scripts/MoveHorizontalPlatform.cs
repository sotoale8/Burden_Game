using UnityEngine;

public class MoveHorizontalPlatform : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento de la plataforma
    public float distance = 5f; // Distancia máxima que la plataforma se moverá desde su posición inicial
    private Vector3 startPosition; // Posición inicial de la plataforma
    private bool movingLeft = true; // Dirección del movimiento

    void Start()
    {
        // Guardar la posición inicial de la plataforma
        startPosition = transform.position;
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

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Player"
        if (collision.gameObject.CompareTag("Captain"))
        {
            // Hacer que el jugador sea hijo de la plataforma
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Verificar si el objeto que deja de colisionar tiene el tag "Player"
        if (collision.gameObject.CompareTag("Captain"))
        {
            // Restaurar la jerarquía original del jugador
            collision.transform.SetParent(null);
        }
    }
}
