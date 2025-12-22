using UnityEngine;
public class PlayerJump: IJumpAble
{
    private Rigidbody2D playerBody;
    private GroundChecker groundChecker;
    private float jumpForce;
    private float jumpHeight;
    private Vector3 startJumpPos = Vector3.zero;
    private bool needKick = false;
  
    public PlayerJump(Rigidbody2D body, float jumpForce, GroundChecker groundChecker, float jumpHeight)
    {
        this.playerBody = body;
        this.jumpForce = jumpForce;
        this.groundChecker = groundChecker;       
        this.jumpHeight = jumpHeight;
    }

    public void TryJump()
    {       
        if (groundChecker.IsGrounded() == false || playerBody.velocity.x < 1)        
            return;  
        playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);
        startJumpPos = playerBody.transform.position;
    }

    public void KickDown()
    {
        if (startJumpPos != Vector3.zero && playerBody.transform.position.y - startJumpPos.y > jumpHeight || playerBody.velocity.y < -0.05f && needKick == true)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x,-jumpForce/2);
            startJumpPos = Vector3.zero;
            needKick = false;
        }

        if (playerBody.velocity.y < -0.05f)
            playerBody.gravityScale = 4;
        else
            playerBody.gravityScale = 1;

        if (groundChecker.IsGrounded() == true)
            needKick = true;
    }
}
