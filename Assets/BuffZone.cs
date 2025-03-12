using UnityEngine;

public class BuffZone : MonoBehaviour
{
    public float speedBuff = 4f; // Cuánto reduce la velocidad
    public float jumpBuff = 450f; // Cuánto reduce el salto

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Captain"))
        {
            CaptainMovement player = collision.GetComponent<CaptainMovement>();
            if (player != null)
            {
                Debug.Log("Jugador entró en la zona de buff");
                player.RestoreSpeedAndJump(speedBuff, jumpBuff);
                AudioManager.Instance.PlayFX("buff");
                Destroy(gameObject, 1f);
            }
        }
    }

}
