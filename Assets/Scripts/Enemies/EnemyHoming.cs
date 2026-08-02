using UnityEngine;

public class EnemyHoming : EnemyBase
{
    [Header("Persecución")]
    public float turnSpeed = 2f;
    public float maxVerticalSpeed = 2f;

    private Transform player;

    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Enemy3";

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    protected override void Move()
    {
        transform.position += new Vector3(speedX * direction * Time.deltaTime, 0, 0);

        if (player == null) return; // si no hay Player en escena todavía, solo vuela recto

        float targetY = player.position.y;
        float currentY = transform.position.y;
        float newY = Mathf.MoveTowards(currentY, targetY, maxVerticalSpeed * turnSpeed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}