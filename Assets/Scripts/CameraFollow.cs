using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Referencia al jugador")]
    public Transform player;

    [Header("Configuración de seguimiento")]
    public float smoothSpeed = 5f;      // Qué tan suave sube la cámara
    public float verticalOffset = 2f;   // Qué tan arriba del jugador se posiciona la cámara

    private float highestY; // Guarda la posición Y más alta alcanzada por la cámara

    void Start()
    {
        highestY = transform.position.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        float targetY = player.position.y + verticalOffset;

        // Solo sube si el jugador superó la altura actual de la cámara, nunca baja
        if (targetY > highestY)
        {
            highestY = targetY;
        }

        Vector3 newPosition = new Vector3(
            transform.position.x,
            Mathf.Lerp(transform.position.y, highestY, smoothSpeed * Time.deltaTime),
            transform.position.z);

        transform.position = newPosition;
    }

    // Método público para que otros scripts (como el spawner de plataformas) 
    // sepan hasta dónde ha subido la cámara
    public float GetCameraTopY()
    {
        Camera cam = GetComponent<Camera>();
        float camHeight = cam.orthographicSize;
        return transform.position.y + camHeight;
    }
}
