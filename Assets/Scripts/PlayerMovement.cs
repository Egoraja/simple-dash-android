using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveAbility
{
    [SerializeField] private MonoBehaviour inputSource;
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private PlayerStopGame playerStopgame;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpHeight;
    private IPlayerInput input;
    private Rigidbody2D body;

    private PlayerRun run;
    private PlayerJump jump;
    private PlayerStopGame playerStopGame;
  

    private bool isActive;

    private void Awake()
    {
        input = inputSource as IPlayerInput;
        body = GetComponent<Rigidbody2D>();
        run = new PlayerRun(body, speed);
        jump = new PlayerJump(body, jumpForce, groundChecker, jumpHeight);
        playerStopGame = new PlayerStopGame(transform);
    }

    private void OnEnable()
    {
        input.OnJumpPressed += jump.TryJump;
    }

    private void OnDisable()
    {
        input.OnJumpPressed -= jump.TryJump;
    }

    public void StartMove()
    {
        isActive = true;
    }

    public void StopMove()
    {
        isActive = false;
        playerStopGame.ErasePayer();
        run.StopRun();
    }

    private void FixedUpdate()
    {
        if (isActive == false)
            return;
        run.Run();
        jump.KickDown();          
    }
}
