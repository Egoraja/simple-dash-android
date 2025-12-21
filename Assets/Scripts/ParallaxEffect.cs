using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform[] backGroundObjects;
    [SerializeField] private float speed = 0.1f;
    private Vector3[] startPosition;
    private Vector3 playerStartPosition;

    private void Start()
    {
        playerStartPosition = playerTransform.position;
        backGroundObjects = new Transform[transform.childCount];
        startPosition = new Vector3[backGroundObjects.Length];
        for (int i = 0; i < backGroundObjects.Length; i++)
        {
            backGroundObjects[i] = transform.GetChild(i);
            startPosition[i] = backGroundObjects[i].position;
        }     
         
    }

    private void Update()
    {
        float targetOffset = playerTransform.position.x - playerStartPosition.x;

        for (int i = 0; i < backGroundObjects.Length; i++)
        {
            backGroundObjects[i].position = new Vector3((startPosition[i].x + (targetOffset)*speed), backGroundObjects[i].position.y);
        }
    }
}
