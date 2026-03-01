using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Classe responsável por controlar o movimento do jogador
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponentInChildren<Rigidbody2D>();
    }

    public void HandleHorizontalMovement(float direction, float speed)
    {
        _rb.linearVelocityX = direction * speed;
    }
    
    public void HandleVerticalMovement(float jumpHeight)
    {
        _rb.linearVelocityY = jumpHeight;
    }

}
