using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [SerializeField] private PlayerSnake _playerSnake;

    private Vector3 _offset;

    public void Initialize()
    {
        _offset = transform.position - _playerSnake.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = _playerSnake.transform.position + _offset;
    }
}
