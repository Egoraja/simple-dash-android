using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private bool isTouched = false;
    
    public bool IsThereTouchOnScreen()
    {
        if (Input.touchCount > 0 && isTouched == false)
        {
            isTouched = true;
            return isTouched;
        }
        else
            return false;
    }

    private void Update()
    {
        if (isTouched == true && Input.touchCount == 0)        
            isTouched = false;        
    }
}
