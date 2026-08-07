using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Referencia al jugador")]
    public Transform player;

    [Header("Velocidad de subida")]
    public float startSpeed = 1f;       // Velocidad inicial de subida (unidades/seg)
    public float maxSpeed = 5f;         // Velocidad máxima que puede alcanzar
    public float acceleration = 0.05f;  // Cuánto aumenta la velocidad por segundo

    [Header("Detección de inicio")]
    public float movementThreshold = 0.1f; // Cuánto debe moverse el jugador para "activar" la subida

    private float currentSpeed;
    private bool hasStarted = false;
    private Vector3 playerStartPosition;

    void Start()
    {
        currentSpeed = startSpeed;

        if (player != null)
        {
            playerStartPosition = player.position;
        }
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (!hasStarted)
        {
            if (Vector3.Distance(player.position, playerStartPosition) > movementThreshold)
            {
                hasStarted = true;
            }
            else
            {
                return;
            }
        }

        currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);

        transform.position += new Vector3(0, currentSpeed * Time.deltaTime, 0);
    }

    // Se mantiene igual para el PlatformSpawnManager
    public float GetCameraTopY()
    {
        Camera cam = GetComponent<Camera>();
        float camHeight = cam.orthographicSize;
        return transform.position.y + camHeight;
    }
}