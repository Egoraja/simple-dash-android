using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.TestTools;

public class NewGroundCheckerTest
{
    [UnityTest]
    public IEnumerator IsGrounded_ReturnsTrue_WhenGroundIsUnderDetector()
    {

        int groundLayer = LayerMask.NameToLayer("Ground");

        var ground = new GameObject("Ground");
        ground.layer = groundLayer;
        var groundCollider = ground.AddComponent<BoxCollider2D>();
        ground.transform.position = Vector3.zero;

        var player = new GameObject("Player");
        var checker = player.AddComponent<GroundChecker>();

        var detector = new GameObject("Detector");
        detector.transform.parent = player.transform;
        detector.transform.position = Vector3.zero;

        SetPrivateField(checker, "detector", new[] { detector.transform });
        SetPrivateField(checker, "groundMask", (LayerMask)LayerMask.GetMask("Ground"));
        SetPrivateField(checker, "radius", 0.5f);
        yield return new WaitForSeconds(2);

        bool isGrounded = checker.IsGrounded();
        Assert.IsTrue(isGrounded);
    }
    private void SetPrivateField(object target, string fieldName, object value)
    {
        var field = target.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);        
        field.SetValue(target, value);
    }
}