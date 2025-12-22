using UnityEngine;

public class PlayerRun
{
    private Rigidbody2D playerBody;
    private float speed;    

    public PlayerRun(Rigidbody2D body, float speed)
    {
        this.playerBody = body;
        this.speed = speed;
    }

    public void Run()
    {
        playerBody.velocity = new Vector2(speed, playerBody.velocity.y);
    }

    public void StopRun()
    {
        playerBody.velocity = Vector2.zero;
        playerBody.isKinematic = true;
    }
}
