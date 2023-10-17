using UnityEngine;
public class SnakeTailsPool : MonoBehaviour
{
    private const int TailsAtOneTime = 5;

    [SerializeField] private int _tailsCount = 20;
    [SerializeField] private PlayerSnake _playerSnake;
    [SerializeField] private SnakeTail _tailTemplate;
    [SerializeField] private Transform _poolContainer;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private SnakeTailSnapper _snapper;
    private Pool<SnakeTail> _pool;

    private void OnDisable()
    {
        _playerSnake.OnFoodTaked -= ActivateNewTails;
    }
   
    public void Initialize()
    {
        _playerSnake.OnFoodTaked += ActivateNewTails;
        _pool = new Pool<SnakeTail>(_tailTemplate, _poolContainer, _tailsCount);
        ActivateNewTails();
    }

    private void ActivateNewTails()
    {
        for (int i = 0; i < TailsAtOneTime; i++)
        {
            SnakeTail _tail = _pool.GetFreeElement();
            _snapper.AddTail(_tail);
            _tail.transform.position = _snapper.GetLastTailPosition();
            _tail.transform.LookAt(_snapper.GetLastTailPosition());
            _tail.gameObject.SetActive(true);
        }
    }


}
