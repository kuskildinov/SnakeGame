using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    private T _template;
    private Transform _container;
    private List<T> _pool;

    public Pool (T template, Transform container,int count)
    {
        _template = template;
        _container = container;
        CreatePool(count);
    }


    private void CreatePool(int count)
    {
        _pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject()
    {
        var createObject = GameObject.Instantiate(_template,_container);
        createObject.gameObject.SetActive(false);
        _pool.Add(createObject);
        return createObject;
    }

    public T GetFreeElement()
    {
        if(HasFreeElement(out T element))
        {
            return element;
        }
        return CreateObject();
    }

    private bool HasFreeElement(out T element)
    {
        foreach(var obj in _pool)
        {
            if(obj.gameObject.activeInHierarchy == false)
            {
                element = obj;
                return true;
            }
        }
        element = null;
        return false;
    }
}
