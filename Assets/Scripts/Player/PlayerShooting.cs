using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    AudioSource shootSound;

    private void Start()
    {
        shootSound = gameObject.AddComponent<AudioSource>();
        shootSound.clip = Resources.Load<AudioClip>("Music/shoot");
        shootSound.volume = 0.5f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        if (PlayerInfo.GetAmmoCount() != 0)
        {
            shootSound.Play();
            Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            PlayerInfo.ReduceAmmo();
        }
    }



}
