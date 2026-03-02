using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpBufferDuration = 0.2f;

    private float _jumpBufferTimer;

    private InputReader _inputReader;
    private PlayerMovement _playerMovement;
    private CollisionSensors _collisionSensors;

    private float _horizontalInput;

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

    private void Update()
    {
        if (_jumpBufferTimer > 0f)
        {
            _jumpBufferTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        _playerMovement.HandleHorizontalMovement(_horizontalInput, moveSpeed);

        if (_jumpBufferTimer > 0f && _collisionSensors.IsGround())
        {
            _playerMovement.HandleVerticalMovement(jumpForce);
            _jumpBufferTimer = 0f;
        }
    }

    private void HandleMoveInput(float direction)
    {
        _horizontalInput = direction;
    }

    private void HandleJump()
    {
        _jumpBufferTimer = jumpBufferDuration;
    }
}
