using UnityEngine;

public class PlayerInputHandling : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private Vector3 _inputVector;

    private void FixedUpdate()
    {
        _inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _playerController.Control(_inputVector);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerController.Jump();
        }
    }
}
