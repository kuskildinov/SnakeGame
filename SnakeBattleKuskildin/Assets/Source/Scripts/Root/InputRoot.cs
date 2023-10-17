using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRoot : CompositeRoot
{
    [SerializeField] private PlayerSnakeMovment playerSnakeMovment;
    [SerializeField] private Joystick _joystick;
    private IInput _input;
    public override void Compose()
    {
        _input = new DesktopInput(_joystick);
        playerSnakeMovment.Initialize(_input);
    }
}
