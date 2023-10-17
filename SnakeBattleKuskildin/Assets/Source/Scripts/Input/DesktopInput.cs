public class DesktopInput : IInput
{
    private Joystick _joystick;
    
    public DesktopInput(Joystick joystick)
    {
        _joystick = joystick;
    }

    public float JoystickHorizontalMove()
    {
        return _joystick.Horizontal;
    }

    public float JoystickVerticalMove()
    {
        return _joystick.Vertical;
    }
}
