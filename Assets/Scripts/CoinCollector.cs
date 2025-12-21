using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    public void AddCoin()
    {
        gameController.CollectCoin();
    }
}
