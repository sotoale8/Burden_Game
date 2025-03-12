using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public float moveDistance; 
    public float moveSpeed; 

    private Vector3 startPosition; 
    private bool movingUp = true; 

    void Start()
    {
        startPosition = transform.position; 
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
}