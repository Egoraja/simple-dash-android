using UnityEngine;

public class CoinAbility : MonoBehaviour, ICoinValue
{
    [SerializeField] private float coinValue = 1;

    private bool isCollect = false;
    public float GetCoinValue { get { return coinValue; } }  
    
    public float CoinValue
    {        
        get
        {           
            if (isCollect == false)
            {
                RemoveVisibility();
                return coinValue;
            }
            else return 0;
        }
    }

    private void RemoveVisibility()
    {       
            isCollect = true;
            transform.localScale = Vector3.zero;       
    }   
}
