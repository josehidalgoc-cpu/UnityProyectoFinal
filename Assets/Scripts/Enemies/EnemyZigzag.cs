using UnityEngine;

public class EnemyZigzag : EnemyBase
{
    [Header("Ondulación")]
    public float amplitude = 1.5f;
    public float frequency = 2f;

    private float startY;
    private float timeOffset;

    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Enemy2";
        startY = transform.position.y;
        timeOffset = Random.Range(0f, Mathf.PI * 2f); // evita que todos oscilen igual
    }

    protected override void Update()
    {
        // startY debe subir junto con la cámara antes de calcular la oscilación
        float cameraDeltaY = cameraTransform.position.y - lastCameraY;
        startY += cameraDeltaY;
        base.Update();
    }

    protected override void Move()
    {
        transform.position += new Vector3(speedX * direction * Time.deltaTime, 0, 0);

        float offsetY = Mathf.Sin((Time.time + timeOffset) * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, startY + offsetY, transform.position.z);
    }
}