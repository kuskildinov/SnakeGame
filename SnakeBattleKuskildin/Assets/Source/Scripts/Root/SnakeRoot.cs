using UnityEngine;
public class SnakeRoot : CompositeRoot
{
    [SerializeField] private SnakeTailSnapper _snakeTailSnapper;
    [SerializeField] private SnakeTailsPool _snakeTailsPool;
    public override void Compose()
    {
        _snakeTailSnapper.Initialize();
        _snakeTailsPool.Initialize();
    }
}
