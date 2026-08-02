using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs de enemigos")]
    public GameObject[] enemyPrefabs;

    [Header("Tiempo entre spawns")]
    public float minTime = 1f;
    public float maxTime = 2f;

    [Header("Dirección de este spawner")]
    [Tooltip("1 = el enemigo vuela hacia la derecha (spawner en el borde izquierdo). -1 = vuela hacia la izquierda (spawner en el borde derecho).")]
    public int spawnDirection = 1;

    void Start()
    {
        StartCoroutine(SpawnCoRutine(0));
    }

    IEnumerator SpawnCoRutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject instance = Instantiate(prefab, transform.position, Quaternion.identity);

        EnemyBase enemy = instance.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.direction = spawnDirection;
        }

        StartCoroutine(SpawnCoRutine(Random.Range(minTime, maxTime)));
    }
}