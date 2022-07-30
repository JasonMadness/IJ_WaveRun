using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndMover : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private Vector3 _targetRotation;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    
    private Vector3 _startPosition;

    public event UnityAction Ended;

    private void OnEnable()
    {
        _startPosition = transform.position;
        StartCoroutine(MoveToTargetPosition());
    }

    private IEnumerator MoveToTargetPosition()
    {
        yield return new WaitForSeconds(_delay);
        float interpolateValue = 0;

        while (interpolateValue < 1)
        {
            transform.position = Vector3.Lerp(_startPosition, _targetPosition, interpolateValue);
            interpolateValue += Time.deltaTime * _speed;
            yield return new WaitForEndOfFrame();
        }

        Ended?.Invoke();
    }
}
