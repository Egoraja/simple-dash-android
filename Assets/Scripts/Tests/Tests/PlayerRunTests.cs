using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerRunTests
{
    [UnityTest]
    public IEnumerator Run_SetsHorizontalVelocity_ToSpeed()
    {

        var player = new GameObject("Player");
        var body = player.AddComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, 0);

        float speed = 5f;
        var run = new PlayerRun(body, speed);
        run.Run();
        yield return new WaitForSeconds(2);

        Assert.AreEqual(speed, body.velocity.x);
    }

    [UnityTest]
    public IEnumerator StopRun_StopsMovement_AndSetsKinematic()
    {
        var player = new GameObject("Player");
        var body = player.AddComponent<Rigidbody2D>();
        body.velocity = new Vector2(5f, 0);
        body.isKinematic = false;

        var run = new PlayerRun(body, 5f);
        run.StopRun();
        yield return new WaitForSeconds(2);

        Assert.AreEqual(Vector2.zero, body.velocity);
        Assert.IsTrue(body.isKinematic);
    }
}
