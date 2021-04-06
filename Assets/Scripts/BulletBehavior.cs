using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            GameObject target = collision.gameObject;
            var force = (target.GetComponent<Rigidbody>().position - transform.position).normalized;

            target.GetComponent<Rigidbody>().AddForce(force * 500, ForceMode.Acceleration);
            target.GetComponent<EnemyInfo>().TakeDamage(1);
        }

        Destroy(gameObject);
    }

}
