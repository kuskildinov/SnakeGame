using UnityEngine;

public class PlayerSnakeMovment : MonoBehaviour
{
    [SerializeField] private Transform _root;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private JoystickHandler _joystickHandler;

    [Header("Movment Settings")]
    [SerializeField, Range(0, 0.5f)] private float _speed;
    [SerializeField, Range(0, 0.2f)] private float _rotationSpeed;

    private IInput _input;
    private Vector3 _currentMoveDirection;
    private Vector3 _newMoveDirection;
    private float _horizontalMove;
    private float _verticalMove;
    
    private void Update()
    {
        ReadInput();       
    }

    private void FixedUpdate()
    {         
        Move(_root.position + _currentMoveDirection * _speed);
        Rotate(_currentMoveDirection * _rotationSpeed);
    }
    
    public void Initialize(IInput input)
    {
        _input = input;
        _currentMoveDirection = _root.forward.normalized;
        _joystickHandler.DirectionChanged += DirectionChanged;
    }

    private void Move(Vector3 newPosition)
    {
        _root.position = newPosition;
    }
    
    private void Rotate(Vector3 moveDirection)
    {
        _root.rotation = Quaternion.LookRotation(moveDirection);
    }

    private void DirectionChanged()
    {
        if (_horizontalMove != 0 && _verticalMove != 0)
        {
            _newMoveDirection = new Vector3(_horizontalMove, 0, _verticalMove).normalized;
            _currentMoveDirection = _newMoveDirection;
        }            
    }

    private void ReadInput()
    {
        _horizontalMove = _input.JoystickHorizontalMove();
        _verticalMove = _input.JoystickVerticalMove();
    }

    private void OnDisable()
    {
        _joystickHandler.DirectionChanged -= DirectionChanged;
    }




}
