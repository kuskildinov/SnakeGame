using System;
using UnityEngine;
public class JoystickHandler : MonoBehaviour
{
    public event Action DirectionChanged;
    private void Update()
    {      
        //Mobile
        if(Input.touchCount > 0)
        {           
            Touch touch = Input.GetTouch(0);            
            DirectionChanged?.Invoke();
        }
        //PC
        if(Input.GetMouseButton(0))
        {           
            DirectionChanged?.Invoke();
        }
    }
}
