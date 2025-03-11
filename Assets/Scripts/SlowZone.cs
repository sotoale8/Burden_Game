using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float speedReduction = 3f; // Cuánto reduce la velocidad
    public float jumpReduction = 400f; // Cuánto reduce el salto

    [SerializeField] private GameObject burdenAnchor;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Captain"))
        {
            CaptainMovement player = collision.GetComponent<CaptainMovement>();
            if (player != null)
            {
                Debug.Log("Jugador entró en la zona lenta");
                player.ReduceSpeedAndJump(speedReduction, jumpReduction);
                burdenAnchor.SetActive(true);
                transform.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            }
        }
    }
}   

