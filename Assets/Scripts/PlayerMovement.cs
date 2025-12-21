using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private float height;
    private Vector3 startjumpPos = Vector3.zero;
    
    [Space(5f)]
    [SerializeField] private Transform groundDetector;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpOffset;
    [SerializeField] private bool isGround;
    [SerializeField] private bool playerIsMoving = false;
    private Vector3 overLapCirclePositionGround;
    private Rigidbody2D playerBody;
    private bool needKick = false;
    private float delay = 1f;

    public bool PlayerIsMoving
    { set { playerIsMoving = value; } }

    private void Start()
    {
        overLapCirclePositionGround = groundDetector.transform.position;
        playerIsMoving = false;
        playerBody = GetComponent<Rigidbody2D>();
    }    

   private void Jump()
    {
        if (isGround == false)
            return;
        else if (inputHandler.IsThereTouchOnScreen())
        {
            startjumpPos = transform.position;
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);            
        }
    }       

    public void StopRun()
    {
        playerIsMoving = false;
        playerBody.velocity = Vector2.zero;
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    private void Run()
    {
        playerBody.velocity = new Vector2(1 * speed, playerBody.velocity.y);       
    }

    private void SpeedIndicator()
    {        
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }
        if (playerBody.velocity.x <= 0.03f)
            StopRun();        
    }

    private void FixedUpdate()
    {       
        if (playerIsMoving)
        {
            overLapCirclePositionGround = groundDetector.transform.position;
            isGround = Physics2D.OverlapCircle(overLapCirclePositionGround, jumpOffset, groundMask);
            if (startjumpPos != Vector3.zero && transform.position.y - startjumpPos.y > height)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, -jumpForce / 2);
                startjumpPos = Vector3.zero;
                needKick = false;
            }
            if (playerBody.velocity.y < -0.05f && needKick == true)
            {
                playerBody.velocity = new Vector2(playerBody.velocity.x, -jumpForce / 2);
                needKick = false;
            }

            if (playerBody.velocity.y < -0.05f)
                playerBody.gravityScale = 4;

            else
                playerBody.gravityScale = 1;


            if (isGround)
                needKick = true;
            Run();
            Jump();
            SpeedIndicator();
        }
    }
}
