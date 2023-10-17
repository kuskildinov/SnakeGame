using System.Collections.Generic;
using UnityEngine;

public class SnakeTailSnapper : MonoBehaviour
{    
    [SerializeField, Range(0,0.5f)] private float _bonesDistance = 0.1f;
    [SerializeField] private SnakeTail _tailPrefab;    
    [SerializeField] private Transform _firstTail;

    private List<SnakeTail> _tails;
    private Vector3 _lastTailPosition;

    private void Update()
    {
        NewTailSnap();
    }

    public void AddTail(SnakeTail newTail)
    {
        _tails.Add(newTail);
    }

    public Vector3 GetLastTailPosition()
    {
        return _lastTailPosition;
    }

    public void Initialize()
    {
        _tails = new List<SnakeTail>();
    }

    private void NewTailSnap()
    {
        float sqrDistance = _bonesDistance * _bonesDistance;
        Vector3 previousBonePosition = _firstTail.transform.position;
         foreach (var tail in _tails)
         {
            if ((tail.transform.position - previousBonePosition).sqrMagnitude > sqrDistance)
            {
             var temp = tail.transform.position;
             tail.transform.position = previousBonePosition;
             tail.transform.LookAt(previousBonePosition);
             previousBonePosition = temp;
             _lastTailPosition = temp;                   
            }
                else
                    break;
         }       
    }
}
