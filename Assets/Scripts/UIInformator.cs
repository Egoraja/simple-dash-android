using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInformator : MonoBehaviour, IUICoinAmount
{
    [SerializeField] private Text coinCounter;
    private float coins;

    private void Start()
    {
        coins = 0;
    }

    public void CollectCoin(float coinValue)
    {
        coins += coinValue;
        coinCounter.text = coins.ToString();
    }  
        
}
