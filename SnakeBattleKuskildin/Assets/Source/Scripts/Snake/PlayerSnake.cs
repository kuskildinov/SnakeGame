using System;
using UnityEngine;

public class PlayerSnake : MonoBehaviour
{
    public event Action OnFoodTaked;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Apple>(out Apple apple))
        {
            apple.gameObject.SetActive(false);
            OnFoodTaked?.Invoke();
        }
    }
}
