using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] levelCompleteEffects;
    [SerializeField] private Button runButton;
    [SerializeField] private PlayerMovement playerMovement;    
  
    public void StartRunButtonPressed()
    {
        playerMovement.StartMove();
        runButton.gameObject.SetActive(false);    
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnLevelComplete()
    {
        foreach (ILevelCompleteEffect effect in levelCompleteEffects)
        {            
            effect.Execute();
        }
    }   
}
