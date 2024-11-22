
using UnityEngine;
using TMPro;

public class BulletShooting : MonoBehaviour
{

    public float bulletSpeed = 100;
    public GameObject bullet;
    [SerializeField] private int maxBullets = 10; // Max bullets 
    [SerializeField] private int totalAmmo = 50; // Total ammo available
    private int currentBullets; // Current bullets 
    private bool isReloading = false; // Prevent actions during reload
    public TextMeshProUGUI reloadText; //Reloading text
    public float reloadTime = 2f; // Time required to reload


    private void Start()
    {
        currentBullets = maxBullets;
        reloadText.text = $"Ammo: {currentBullets}/{maxBullets}";
    }

    void BulletSpwan()
    {

        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed * Time.deltaTime, ForceMode.VelocityChange);
        Destroy(tempBullet, 2f);
        currentBullets--;
    }
    void Update()
    {
        // Firing bullets
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BulletSpwan();
            Shoot();
        }

        // Reloading
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentBullets < maxBullets && totalAmmo > 0)
        {
            StartCoroutine(Reload());
        }
        void Shoot()
        {
            if (currentBullets > 0)
            {
                Debug.Log("Bullet fired!");
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

        System.Collections.IEnumerator Reload()
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
   

