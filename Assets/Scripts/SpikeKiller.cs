using UnityEngine;

public class SpikeKiller : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.TryGetComponent(out PlayerMovement playerMovement))
            playerMovement.StopRun();
    }   
}
