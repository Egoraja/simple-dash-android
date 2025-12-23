using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.TestTools;


   public class PlayerStopperTest
{
    [UnityTest]
    public IEnumerator Stopped_ReturnsTrue_WhenPlayerStopped()
    {
        var player = new GameObject("Player");
        var playerCollider = player.AddComponent<BoxCollider2D>();
        var body = player.AddComponent<Rigidbody2D>();
        float speed = 5f;
        body.velocity = new Vector2(speed, 0);
        var run = new PlayerRun(body, speed);
        var playerMovement = player.AddComponent<PlayerMovement>();
        playerMovement.Run = run;

        var stopper = new GameObject("Spike");
        var spikeKiller = stopper.AddComponent<SpikeKiller>();
        var spikeCollider = stopper.AddComponent<BoxCollider2D>();
        spikeCollider.isTrigger = true;

        player.transform.position = Vector3.zero;
        stopper.transform.position = Vector3.zero;
       
        yield return new WaitForSeconds(2);
        Assert.AreEqual(Vector2.zero, body.velocity);       
    }
}
