using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private IUICoinAmount uICoinAmount;

    private void Start()
    {
        uICoinAmount = GetComponent<IUICoinAmount>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ICoinValue coinValue))
            AddCoin(coinValue.CoinValue);
    }

    private void AddCoin(float coinValue)
    {
        uICoinAmount.CollectCoin(coinValue);      
    }
}
