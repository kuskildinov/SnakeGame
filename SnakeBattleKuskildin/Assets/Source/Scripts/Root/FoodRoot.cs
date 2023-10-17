using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRoot : CompositeRoot
{
    [SerializeField] private FoodPool _foodPool;
    [SerializeField] private FoodSpawner _foodSpawner;
    public override void Compose()
    {
        _foodPool.Initialize();
        _foodSpawner.Initialize();
    }
}
