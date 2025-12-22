using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevetComplete : MonoBehaviour, ILevelCompleteEffect
{
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private float timer;
    private float currentTime;
    private bool islevelCompleted = false;
    private void Start()
    {
        levelCompletePanel.SetActive(false);
    }

    public void Execute()
    {
        islevelCompleted = true;
        currentTime = Time.time;
    }

    private void Update()
    {
        if (islevelCompleted == true)
        {
            if (Time.time - currentTime >= timer)
            {
                levelCompletePanel.SetActive(true);
                islevelCompleted = false;
            }            
        }          
    }
}
