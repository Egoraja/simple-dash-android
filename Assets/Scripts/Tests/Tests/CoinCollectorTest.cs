using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CoinCollectorTest
{    
    [UnityTest]
    public IEnumerator CoinCollectorTestWithEnumeratorPasses()
    {
        var player = new GameObject("Player");
        var uICoinAmount = player.AddComponent<UIInformator>();
        var playerCollider = player.AddComponent<BoxCollider2D>();
        var rigidBody = player.AddComponent<Rigidbody2D>();
        var collector = player.AddComponent<CoinCollector>(); 

        var coin = new GameObject("Coin");
        var coinCollider = coin.AddComponent<BoxCollider2D>();
        coinCollider.isTrigger = true;
        var testCoin  = coin.AddComponent<CoinAbility>();
        coin.transform.position = player.transform.position;
        yield return new WaitForSeconds(2);
        
        Assert.AreEqual(testCoin.GetCoinValue, collector.Coins);
        Assert.AreEqual(uICoinAmount.CoinAmount, collector.Coins.ToString());
    }
}
