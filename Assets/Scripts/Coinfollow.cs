using UnityEngine;

public class Coinfollow : MonoBehaviour
{
    public Transform cameraTransform; // Asigna la transformada de la cámara aquí
    public Vector3 offset; // Ajusta esto para cambiar la posición relativa al Limpiador

    void Update()
    {
        if (cameraTransform != null)
        {
            transform.position = new Vector3(cameraTransform.position.x + offset.x, cameraTransform.position.y + offset.y, offset.z);
        }
    }
}