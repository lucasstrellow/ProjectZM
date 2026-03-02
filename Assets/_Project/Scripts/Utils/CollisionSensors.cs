using UnityEngine;

public class CollisionSensors : MonoBehaviour
{
    [Header("Ground Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGround()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = IsGround() ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}
