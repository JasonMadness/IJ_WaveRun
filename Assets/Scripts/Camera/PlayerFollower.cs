using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private CameraOffset _start;
    [SerializeField] private CameraOffset _end;
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _mainOffset;
    [SerializeField] private Vector3 _endingOffset;
    [SerializeField] private Vector3 _endingRotation;
    [SerializeField] private float _endingDelay;
    [SerializeField] private float _speed;

    private Vector3 _offset;

    private void OnEnable()
    {
        _player.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _player.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        StartCoroutine(ChangeOffset());
    }

    private IEnumerator ChangeOffset()
    {
        yield return new WaitForSeconds(_endingDelay);
        float interpolateValue = 0;

        while (interpolateValue < 1)
        {
            _offset = Vector3.Lerp(_offset, _endingOffset, interpolateValue);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, Quaternion.Euler(_endingRotation), interpolateValue);
            interpolateValue += Time.deltaTime * _speed;
            yield return new WaitForEndOfFrame();
        }
    }

    private void Start()
    {
        _offset = _mainOffset;
    }

    private void LateUpdate()
    {
        transform.position = _player.transform.position + _offset;
    }
}
