using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] private Button runButton;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Text coinCounter;
    [SerializeField] private GameObject completeLevelPanel;
    [SerializeField]private float timer = 2;
    private int coins;
    private float currentTime;

    private void Start()
    {
        currentTime = 0;
        completeLevelPanel.SetActive(false);
        coins = 0;
    }
    public void StartRunButtonPressed()
    {
        playerMovement.PlayerIsMoving = true;
        runButton.gameObject.SetActive(false);    
    }

    public void ResstartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CollectCoin()
    {
        coins++;
        coinCounter.text = coins.ToString();    
    }       

    public void OnLevelComplete()        
    {        
        currentTime = timer;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                completeLevelPanel.SetActive(true);
        }
    }
}
