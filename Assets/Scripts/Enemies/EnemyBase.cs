using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Movimiento")]
    public float speedX = 3f;
    public int direction = 1; // 1 = derecha, -1 = izquierda

    protected Transform cameraTransform;
    protected float lastCameraY;

    protected virtual void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraY = cameraTransform.position.y;

        // Voltea el sprite según la dirección de vuelo
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }

    protected virtual void Update()
    {
        // Sigue la subida de la cámara en Y
        float cameraDeltaY = cameraTransform.position.y - lastCameraY;
        transform.position += new Vector3(0, cameraDeltaY, 0);
        lastCameraY = cameraTransform.position.y;

        Move();
    }

    // Cada tipo de enemigo implementa su propio patrón de movimiento en X/Y
    protected abstract void Move();
}
