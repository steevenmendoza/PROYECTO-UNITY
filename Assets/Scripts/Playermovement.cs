using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de incluir este namespace para usar SceneManager

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public float jumpForce = 10f; // Fuerza del salto
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D
    private bool isGrounded; // Para verificar si el jugador está tocando el suelo
    public GameManager GameManager;
    public GameObject Bullet; // Referencia al prefab del objeto Bullet
    public Transform bulletSpawnPoint; // Punto de instanciación del Bullet

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el componente Rigidbody2D al iniciar
    }

    void Update()
    {
        Move(); // Llamada a la función de movimiento

        // Detectar la entrada de salto y si el jugador está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(); // Llamada a la función de salto
        }

        // Nueva funcionalidad: disparar un bullet
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot(); // Llamada a la función de disparo
        }
    }

    void Move()
    {
        // Obtener entrada del teclado
        float x = Input.GetAxisRaw("Horizontal");
        // Crear un nuevo vector de velocidad
        Vector2 targetVelocity = new Vector2(x * speed, rb.velocity.y);
        // Aplicar la velocidad al Rigidbody2D
        rb.velocity = targetVelocity;
    }

    void Jump()
    {
        // Aplicar una fuerza de salto en dirección vertical
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGrounded = false; // El jugador ya no está en el suelo
    }

    // Función para disparar
    void Shoot()
    {
        // Instanciar el objeto Bullet en la posición y rotación del punto de disparo
        Instantiate(Bullet, bulletSpawnPoint.position, Quaternion.identity);
    }

    // Detectar colisiones para manejar tanto el suelo como los objetos "BadItem"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // El jugador toca el suelo
        }
        else if (collision.collider.CompareTag("Baditem"))
        {
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.CompareTag("Coin"))
        {
            GameManager.AddScore(); // Suponiendo que cada moneda añade 1 al score
            Destroy(collision.gameObject); // Opcional: destruir el objeto coin tras recogerlo
        }
    }

    // Opcional: Detectar cuando el jugador deja de tocar el suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // El jugador deja de tocar el suelo
        }
    }
}
