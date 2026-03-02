using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 10f;

    private InputReader _inputReader;
    private PlayerMovement _playerMovement;
    private CollisionSensors _collisionSensors;

    private float _horizontalInput;
    private bool _jumpInput;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerMovement = GetComponent<PlayerMovement>();
        _collisionSensors = GetComponent<CollisionSensors>();
    }

    private void OnEnable()
    {
        _inputReader.OnMoveEvent += HandleMoveInput;
        _inputReader.OnJumpEvent += HandleJump;
    }

    private void OnDisable()
    {
        _inputReader.OnMoveEvent -= HandleMoveInput;
        _inputReader.OnJumpEvent -= HandleJump;
    }


    private void FixedUpdate()
    {
        _playerMovement.HandleHorizontalMovement(_horizontalInput, moveSpeed);

        if (_collisionSensors.IsGround() && _jumpInput)
        {
            _playerMovement.HandleVerticalMovement(jumpForce);
            _jumpInput = false;
        }
    }

    private void HandleMoveInput(float direction)
    {
        _horizontalInput = direction;
    }

    private void HandleJump()
    {
        _jumpInput = true;
    }
}
