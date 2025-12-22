using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopGame
{
    private Transform playerTransform;
    public PlayerStopGame(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }

    public void ErasePayer()
    {       
        playerTransform.localScale = Vector3.zero;
    }   
}
