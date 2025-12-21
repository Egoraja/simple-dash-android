using UnityEngine;

public class CoinAbility : MonoBehaviour
{
    private bool isCollect = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CoinCollector coinCollector) && isCollect == false)
        {
            isCollect = true;
            coinCollector.AddCoin();
            transform.localScale = Vector3.zero;
        }
    }
}
