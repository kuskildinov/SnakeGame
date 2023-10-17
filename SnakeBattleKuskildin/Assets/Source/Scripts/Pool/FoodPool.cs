using UnityEngine;

public class FoodPool : MonoBehaviour
{
    [SerializeField] private int _foodCount = 20;   
    [SerializeField] private Food _foodTemplate;
    [SerializeField] private Transform _poolContainer;      
   
    private Pool<Food> _pool;

    public void Initialize()
    {        
        _pool = new Pool<Food>(_foodTemplate, _poolContainer, _foodCount);    
    }

    public Food GetNewFood()
    {
        Food _food = _pool.GetFreeElement();
        return _food;
    }  
}
