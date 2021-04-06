using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMoving player = collision.gameObject.GetComponent<PlayerMoving>();
            player.EnemyCollision(gameObject.transform, damage, 500);
        }
    }
}
