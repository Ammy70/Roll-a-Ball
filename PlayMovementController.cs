using UnityEngine;
public class PlayerMovementController : MonoBehaviour
{
    public int speed;
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 _movementDirection = new Vector3(horizontal, 0, vertical);
        _movementDirection.Normalize();
        transform.Translate(_movementDirection * speed*Time.deltaTime,Space.World);
        if(_movementDirection != Vector3.zero)
        {
            transform.forward = _movementDirection;
        }


        //animator.setfloat(speed);
       


    }
   
}
