using UnityEngine;

public class EnemyGlider : EnemyBase
{
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Enemy1";
    }

    protected override void Move()
    {
        transform.position += new Vector3(speedX * direction * Time.deltaTime, 0, 0);
    }
}
