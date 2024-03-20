using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public string sceneToLoad = "GameOverScene"; // Nombre de la escena a cargar después de la muerte.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Asegúrate de que el tag del jugador sea "Player".
        {
            // Aquí puedes agregar cualquier lógica adicional que necesites antes de reiniciar el juego.
            // Por ejemplo, reproducir un sonido de muerte, una animación, mostrar una pantalla de game over, etc.

            // Carga la escena de game over o reinicia la escena actual.
SceneManager.LoadScene(SceneManager.GetActiveScene().name);        }
    }
}
