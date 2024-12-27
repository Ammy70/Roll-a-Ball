
using UnityEngine;

public class BulletsSpwan : MonoBehaviour
{
    [SerializeField] private GameObject bullet;   // game object of bullts
    [SerializeField] private int currentBullets; // Current bullets 
    [SerializeField] private float bulletSpeed = 100;
    [SerializeField] private Transform _trasform;
    // speed of a bullets
    private void Start()
    {
       
        BulletShootSpwan();
    }
    public void BulletShootSpwan()
    {
        GameObject tempBullet = Instantiate(bullet, _trasform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.velocity = _trasform.TransformDirection(new Vector3(0, 0, bulletSpeed));
        currentBullets--;
        
    }
   
}
