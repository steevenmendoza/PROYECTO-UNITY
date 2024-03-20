using UnityEngine;
using System.Collections;

public class Coingenerator : MonoBehaviour
{
    public GameObject coinPrefab; // Asigna aquí tu prefab de moneda en el Inspector
    public float groundYPosition = 0.5f; // La altura del suelo más un pequeño offset para las monedas
    public float spawnDistanceAhead = 10f; // Distancia adelante de la cámara para spawnear las monedas
    public float minTime = 1f; // Tiempo mínimo entre spawns
    public float maxTime = 2f; // Tiempo máximo entre spawns

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Obtiene la referencia a la cámara principal
        StartCoroutine(SpawnCoinCoroutine());
    }

    IEnumerator SpawnCoinCoroutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            // Calcula la posición X adelante de la cámara para spawnear las monedas
            Vector3 spawnPosition = mainCamera.transform.position + new Vector3(spawnDistanceAhead, groundYPosition, -mainCamera.transform.position.z);

            // Crea una nueva moneda en la posición calculada
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
