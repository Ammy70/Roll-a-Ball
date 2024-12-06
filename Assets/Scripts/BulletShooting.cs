
using UnityEngine;
using TMPro;
using System.Collections;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] BulletsSpwan _bulletSpwan;
    public Animator _animator;
    [SerializeField] private int currentBullets; // Current bullets 
    [SerializeField] private int totalAmmo;
    [SerializeField] private bool isReloading = false; // Prevent actions during reload
    [SerializeField] private TextMeshProUGUI reloadText; //Reloading text
    [SerializeField] private float reloadTime = 2f; // Time required to reload
    private float shootCooldown = 1.5f; // Time in seconds between shots
    private float lastShootTime = 1.7f;  // Tracks the time of the last shot
    [SerializeField] private int maxBullets = 10; // Max bullets 
    [SerializeField] private GameObject bullet;   // game object of bullts
    AudioSource m_ShootingSound;
    public bool shoot = false;

    private void Start()
    {
        currentBullets = maxBullets;
        reloadText.text = $"Ammo: {currentBullets}/{maxBullets}";
        m_ShootingSound = GetComponent<AudioSource>();
    }

  
    void Update()
    {
        // Firing bullets
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShootTime + shootCooldown)
        {
            _bulletSpwan.BulletShootSpwan();
            ShootServier();
            m_ShootingSound.Play();
            lastShootTime = Time.time; // Update the last shot time
            shoot = true;
            print("This is porne");
            _animator.SetBool("Shoot", true);
        }
        else
        {
            shoot = false;
            _animator.SetBool("Shoot", false);
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
                    //_animator.SetTrigger("Reload");
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


   

