using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float standardSpeed = 5.0f;
    [SerializeField] private float fastSpeed = 10.0f;

    private float moveSpeed;
    private bool isSoundPlaying;
    private AudioSource stepSound;
    private Vector3 mousePos;

    private void Start()
    {
        moveSpeed = standardSpeed;
        stepSound = gameObject.AddComponent<AudioSource>();
        stepSound.clip = Resources.Load<AudioClip>("Music/steps");
        stepSound.loop = true;
        stepSound.volume = 0.5f;
    }

    private void Update()
    {
        // Look at cursor
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePos.Set(hit.point.x, 0.5f, hit.point.z);
            transform.LookAt(mousePos);
        }
    }

    private void FixedUpdate()
    {
        // Player Move
        float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
        float deltaZ = Input.GetAxis("Vertical") * moveSpeed;

        if ((deltaX != 0 || deltaZ != 0) && isSoundPlaying == false)
        {
            stepSound.Play();
            isSoundPlaying = true;
        }

        if (deltaX == 0 && deltaZ == 0)
        {
            stepSound.Stop();
            isSoundPlaying = false;
        }

        Vector3 direction = new Vector3(deltaX, 0, deltaZ);
        direction = Vector3.ClampMagnitude(direction, moveSpeed);
        transform.position += direction * Time.fixedDeltaTime;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = fastSpeed;
            stepSound.pitch = fastSpeed / standardSpeed;
        }
        else
        {
            moveSpeed = standardSpeed;
            stepSound.pitch = 1;
        }
    }

    public void EnemyCollision(Transform enemyTransform, float damage, float force)
    {
        PlayerInfo.TakeDamage(damage);
        GetComponent<Rigidbody>().AddForce((transform.position - enemyTransform.position).normalized * force, ForceMode.Acceleration);
    }
}
