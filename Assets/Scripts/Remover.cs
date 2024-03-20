using UnityEngine;

public class Destructor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto es un clon de "Ground"
        if (other.gameObject.name == "Ground(Clone)")
        {
            // Destruye el objeto
            Destroy(other.gameObject);
        }
    }
}
