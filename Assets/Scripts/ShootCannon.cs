using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint; // Punto de disparo
    public float bulletForce = 20f; // Fuerza del disparo
    public float fireRate = 1.5f; // Tiempo entre disparos en segundos
    private float nextFireTime = 0f;
    private bool targetOn = false;
    private CaptainMovement player;
    void Start()
    {
         player=GameObject.Find("Captain").GetComponent<CaptainMovement>();
    }

    void Update()
    {
        if (targetOn && Time.time >= nextFireTime)
        {
            ShootBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootBullet()
    {
        // Instanciar la bala en el punto de disparo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Obtener el componente Rigidbody2D de la bala
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Aplicar una fuerza en la dirección izquierda
        rb.linearVelocity = Vector2.left * bulletForce;

        // Destruir la bala después de 2 segundos
        Destroy(bullet, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Captain"))
        {
            targetOn = true;
            player.onPlatform=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Captain"))
        {
            targetOn = false;
            player.onPlatform=false;
        }
    }
}
