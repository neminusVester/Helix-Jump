using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(-0.2f, 0.9f, -2.75f);
    private float _cameraDelay = -1f;

    public void Init(Transform newTarget)
    {
        _target = newTarget;
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (!_target) return;

        Vector3 targetPosition = _target.position + _offset;
        if (_target.position.y < transform.position.y + _cameraDelay || _target.position.y > transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }


}
