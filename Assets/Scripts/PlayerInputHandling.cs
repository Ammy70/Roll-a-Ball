using UnityEngine;
public class PlayerInputHandling : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    []
   
    private Vector3 _inputVector;
    Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * 5;
        float vertical = Input.GetAxis("Vertical") * 5;
        _inputVector = rig.velocity;
        _inputVector.x = horizontal;
        _inputVector.z = vertical;
        rig.velocity = _inputVector;
    }
   
}
