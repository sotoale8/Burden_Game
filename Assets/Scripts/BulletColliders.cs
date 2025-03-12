using UnityEngine;

public class BulletColliders : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el jugador deja de colisionar con la plataforma y esta está cayendo
        if (collision.gameObject.CompareTag("Captain"))
        {
            GameManager.Instance.ReloadCurrentScene();
        }
    }
}
