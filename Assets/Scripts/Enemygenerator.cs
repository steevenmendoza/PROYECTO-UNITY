using UnityEngine;
using System.Collections;

public class CactusSpawner : MonoBehaviour
{
    public GameObject cactusPrefab; // Asigna aquí tu prefab de cactus en el Inspector
    public float spawnRate = 2f; // Tiempo en segundos entre cada generación de cactus
    public float groundYPosition = 0f; // La posición en Y del suelo donde se generarán los cactus
    public Vector2 spawnRangeX = new Vector2(10f, 20f); // Rango de distancia en X para la próxima generación de cactus

    private void Start()
    {
        StartCoroutine(SpawnCactus());
    }

    IEnumerator SpawnCactus()
    {
        while (true)
        {
            // Espera un tiempo determinado antes de generar el próximo cactus
            yield return new WaitForSeconds(spawnRate);

            // Calcula la posición aleatoria en X para el próximo cactus
            float spawnXPosition = transform.position.x + Random.Range(spawnRangeX.x, spawnRangeX.y);

            // La posición de generación es una combinación del spawn en X y la posición del suelo en Y
            Vector3 spawnPosition = new Vector3(spawnXPosition, groundYPosition, 0f);

            // Crea un nuevo cactus en la posición calculada
            Instantiate(cactusPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
