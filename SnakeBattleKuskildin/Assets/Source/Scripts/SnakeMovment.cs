using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovment : MonoBehaviour
{
    public List<Transform> Tails;
    public float BonesDistance;
    public GameObject BonePrefabs;
    public float Speed;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        Move(_transform.position + _transform.forward * Speed);

        float angle = Input.GetAxis("Horizontal") * 4;
        _transform.Rotate(0,angle,0);

    }

    private void Move(Vector3 newPosition)
    {
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 previousBonePosition = _transform.position;

        foreach (var bone in Tails)
        {
            if ((bone.position - previousBonePosition).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                bone.position = previousBonePosition;
                previousBonePosition = temp;
            }
            else
                break;
        }
        _transform.position = newPosition;
    }
}
