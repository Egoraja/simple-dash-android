using UnityEngine;

public class CoinAbility : MonoBehaviour, ICoinValue
{
    [SerializeField] private float coinValue;

    private bool isCollect = false;

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
