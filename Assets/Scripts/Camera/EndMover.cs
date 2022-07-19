using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMover : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private Vector3 _targetRotation;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;

    private void Start()
    {
        StartCoroutine(MoveToTargetPosition());
    }

    private IEnumerator MoveToTargetPosition()
    {
        yield return new WaitForSeconds(_delay);
        float interpolateValue = 0;

        while (interpolateValue < 1)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, interpolateValue);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetRotation), interpolateValue);
            interpolateValue += Time.deltaTime * _speed;
            yield return new WaitForEndOfFrame();
        }
    }
}
