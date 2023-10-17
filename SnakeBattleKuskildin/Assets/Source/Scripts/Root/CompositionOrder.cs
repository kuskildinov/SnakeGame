using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositionOrder : MonoBehaviour
{
    [SerializeField] private List<CompositeRoot> _order;

    private void Awake()
    {
        foreach(var compositeRoot in _order)
        {
            compositeRoot.Compose();
        }
    }
}
