using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.TestTools;


public class PlayerJumpTest
{
    [UnityTest]
    public IEnumerator Jump_SetsVerticalVelocity_ToJump()
    {
        var player = new GameObject("Player");
        var body = player.AddComponent<Rigidbody2D>();
        body.velocity = new Vector2(0, 2);
        var checker = player.AddComponent<GroundChecker>();

        var detector = new GameObject("Detector");
        detector.transform.parent = player.transform;
        detector.transform.position = Vector3.zero;

        SetPrivateField(checker, "detector", new[] { detector.transform });
        SetPrivateField(checker, "groundMask", (LayerMask)LayerMask.GetMask("Ground"));
        SetPrivateField(checker, "radius", 0.5f);

        float jumpForse = 12f;
        float jumpHeight = 2f;
        var jump = new PlayerJump(body, jumpForse, checker, jumpHeight);
        jump.TryJump();
        yield return new WaitForSeconds(0.2f);

        Assert.IsTrue(body.velocity.y > 0);
    }

    private void SetPrivateField(object target, string fieldName, object value)
    {
        var field = target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        field.SetValue(target, value);
    }
}

