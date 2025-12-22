using System;
using UnityEngine;

public class TouchInputHandler : MonoBehaviour, IPlayerInput
{
    private bool isTouched = false;
    public event Action OnJumpPressed;

    private void Update()
    {
        if (Input.touchCount > 0 && isTouched == false)
        {
            isTouched = true;
            OnJumpPressed?.Invoke();
        }

        if (Input.touchCount == 0)
            isTouched = false;
    }
}
