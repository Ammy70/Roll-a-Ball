using UnityEngine;
public class PlayerInputHandling : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 700f;
    public Animator _animation;
    private void FixedUpdate()
    {

        // Get Input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement and rotation
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
        if (movement.magnitude > 0.1f)
        {
            // Move character
            transform.Translate(movement * speed * Time.deltaTime, Space.World);

        }
        // Rotate character to face direction
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // Set animator speed parameter
            _animation.SetFloat("speed", movement.magnitude);
    }
}





