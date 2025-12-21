using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.StopRun();
            gameController.OnLevelComplete();        
        }
    }
}
