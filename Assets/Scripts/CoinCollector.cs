using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private IUICoinAmount uICoinAmount;
    private float coins = 0;
    public float Coins { get { return coins; } }

    private void Start()
    {
        uICoinAmount = GetComponent<IUICoinAmount>();       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICoinValue coinValue))
        {
            coins += coinValue.CoinValue;
            AddCoinInUI(coins);
        }
    }

    private void AddCoinInUI(float coinValue)
    {        
        uICoinAmount.CollectCoin(coinValue);      
    }
}
