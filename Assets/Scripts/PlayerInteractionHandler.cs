
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
           // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            
          // _playerController.AddCoin();
            
            Destroy(other.gameObject);
            Destroy(gameObject);




        }
    }
}
