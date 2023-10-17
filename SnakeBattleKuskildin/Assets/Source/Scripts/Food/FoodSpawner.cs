using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private PlayerSnake _playerSnake;
    [SerializeField] private FoodPool _foodPool;
    [SerializeField] private int _startFoodCount;
    [Header("Game Field Scale")]
    [SerializeField] private Vector2 _gameFieldScale = new Vector2(100f, 100f);

    private Vector3 _spawnPoint;
    
    public void Initialize()
    {        
        SpawnSomeFood(_startFoodCount);
        _playerSnake.OnFoodTaked += ChangeSpawnPoint;
        _playerSnake.OnFoodTaked += SpawnOneFood;
    }

    private void SpawnSomeFood(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnOneFood();
            ChangeSpawnPoint();
        }
    }

    private void SpawnOneFood()
    {
        Food food = _foodPool.GetNewFood();
        food.transform.position = _spawnPoint;
        food.gameObject.SetActive(true);
    }

    private void ChangeSpawnPoint()
    {
        _spawnPoint = new Vector3(Random.Range(1, _gameFieldScale.x), transform.position.y, Random.Range(1, _gameFieldScale.y));
    }
}
