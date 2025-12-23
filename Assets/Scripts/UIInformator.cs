using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInformator : MonoBehaviour, IUICoinAmount
{
    [SerializeField] private Text coinCounter;    
    public string CoinAmount { get { return coins.ToString(); } }
    private float coins;

    private void Start()
    {
        coins = 0;
        UpdateUI();
    }

    public void CollectCoin(float coinValue)
    {
        coins += coinValue;        
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (coinCounter == null)
            return;
        coinCounter.text = coins.ToString();
    }
}
