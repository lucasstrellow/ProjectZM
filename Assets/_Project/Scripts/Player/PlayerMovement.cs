using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Classe responsável por controlar o movimento do jogador
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
    }

    public void HandleMovement(float direction, float speed)
    {
        _rb.linearVelocityX = direction * speed;
    }
    
    public void HandleJump(float jumpHeight)
    {
        _rb.linearVelocityY = jumpHeight;
    }

}
