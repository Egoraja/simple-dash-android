using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform[] detector;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float radius;

    public bool IsGrounded()
    {
        bool isGround = false;
        foreach (var item in detector)
        {
            if (Physics2D.OverlapCircle(item.position, radius, groundMask) == true)
            {
                isGround = true;
                return isGround;               
            }                                                            
        }
        return isGround;
    }
}
