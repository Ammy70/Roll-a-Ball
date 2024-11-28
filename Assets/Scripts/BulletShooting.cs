
using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 100;
    [SerializeField] private GameObject bullet;
    [SerializeField] private int maxBullets = 10; // Max bullets 
    [SerializeField] private int totalAmmo = 50; // Total ammo available
    [SerializeField] private int currentBullets; // Current bullets 
    [SerializeField] private bool isReloading = false; // Prevent actions during reload
    [SerializeField] private TextMeshProUGUI reloadText; //Reloading text
    [SerializeField] private float reloadTime = 2f; // Time required to reload
    private float shootCooldown = 0.5f; // Time in seconds between shots
    private float lastShootTime = 0f;  // Tracks the time of the last shot
    AudioSource m_ShootingSound;
    private void Start()
    {
        currentBullets = maxBullets;
        reloadText.text = $"Ammo: {currentBullets}/{maxBullets}";
        m_ShootingSound = GetComponent<AudioSource>();
    }

    void Shoot()
    {
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        currentBullets--;
    }
    void Update()
    {
        // Firing bullets
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
            ShootServier();
            m_ShootingSound.Play();
            lastShootTime = Time.time; // Update the last shot time
        }
        // Reloading
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentBullets < maxBullets && totalAmmo > 0)
        {
            StartCoroutine(Reload());
        }
        void ShootServier()
        {
            if (currentBullets > 0)
            {            
                currentBullets--;
                reloadText.text = $"Ammo: {currentBullets}/{maxBullets}";
                if (currentBullets == 0)
                {
                    StartCoroutine(Reload());
                }
            }
            else
            {
                Debug.Log("Out of ammo!");
            }
        }
        IEnumerator Reload()
        {
            isReloading = true;
            reloadText.text = "Reloading...";
            yield return new WaitForSeconds(reloadTime);

            currentBullets = maxBullets;
            reloadText.text = $"Ammo: {currentBullets}/{maxBullets}";
            isReloading = false;
        }
    } 
}

   

