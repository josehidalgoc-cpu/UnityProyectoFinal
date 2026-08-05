using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformSpawnManager : MonoBehaviour
{
    [System.Serializable]
    public class PlatformColumn
    {
        public string name = "Columna";
        public float xPosition;
        public GameObject platformPrefab;

        [HideInInspector] public float lastSpawnY;
        [HideInInspector] public List<GameObject> activePlatforms = new List<GameObject>();
    }

    [Header("Columnas de plataformas (una por cada tipo)")]
    public PlatformColumn[] columns = new PlatformColumn[4];

    [Header("Referencia a la cámara")]
    public CameraFollow cameraFollow;

    [Header("Espaciado vertical entre plataformas de la misma columna")]
    public float minVerticalSpacing = 2.5f;
    public float maxVerticalSpacing = 4f;

    [Header("Qué tan adelante generar respecto al borde de cámara")]
    public float spawnBuffer = 5f;

    [Header("Limpieza de plataformas viejas")]
    public float destroyBufferBelowCamera = 3f;

    void Start()
    {
        foreach (PlatformColumn column in columns)
        {
            column.lastSpawnY = transform.position.y;

            // Colchón inicial de plataformas por columna
            for (int i = 0; i < 5; i++)
            {
                SpawnPlatformInColumn(column);
            }
        }
    }

    void Update()
    {
        float cameraTopY = cameraFollow.GetCameraTopY();

        foreach (PlatformColumn column in columns)
        {
            while (column.lastSpawnY < cameraTopY + spawnBuffer)
            {
                SpawnPlatformInColumn(column);
            }

            CleanupOldPlatforms(column);
        }
    }

    void SpawnPlatformInColumn(PlatformColumn column)
    {
        column.lastSpawnY += Random.Range(minVerticalSpacing, maxVerticalSpacing);

        GameObject instance = Instantiate(
            column.platformPrefab,
            new Vector3(column.xPosition, column.lastSpawnY, 0),
            Quaternion.identity);

        column.activePlatforms.Add(instance);
    }

    void CleanupOldPlatforms(PlatformColumn column)
    {
        float cameraBottomY = cameraFollow.transform.position.y - destroyBufferBelowCamera;

        for (int i = column.activePlatforms.Count - 1; i >= 0; i--)
        {
            if (column.activePlatforms[i] == null)
            {
                column.activePlatforms.RemoveAt(i);
                continue;
            }

            if (column.activePlatforms[i].transform.position.y < cameraBottomY)
            {
                Destroy(column.activePlatforms[i]);
                column.activePlatforms.RemoveAt(i);
            }
        }
    }
}