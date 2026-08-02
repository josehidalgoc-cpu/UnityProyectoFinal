using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    [SerializeField] private string[] tagsToDestroy = { "Enemy1", "Enemy2", "Enemy3" };

    void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string t in tagsToDestroy)
        {
            if (collision.CompareTag(t))
            {
                Destroy(collision.gameObject);
                return;
            }
        }
    }
}