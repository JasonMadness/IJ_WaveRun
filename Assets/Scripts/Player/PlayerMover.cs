using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.Events;

[RequireComponent(typeof(EndMover))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotationOffset;
    [SerializeField] private float _horizontalBoundary;
    [SerializeField] private float _startOffset;

    public event UnityAction RoadEnded;

    private float _distanceTraveled;
    private float _horizontalPosition;
    private bool _onFinish = false;

    private void Start()
    {
        _distanceTraveled += _startOffset;
    }

    private void Move()
    {
        Vector3 moveDirection = _pathCreator.path.GetPointAtDistance(_distanceTraveled);
        _horizontalPosition -= Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position = new Vector3(moveDirection.x, moveDirection.y, _horizontalPosition);
    }

    private void ClampHorizontalPosition()
    {
        _horizontalPosition = Mathf.Clamp(_horizontalPosition, -_horizontalBoundary, _horizontalBoundary);
    }

    private void Rotate()
    {
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTraveled) * Quaternion.Euler(_rotationOffset);
    }

    private void Update()
    {
        if (_onFinish == false)
        {
            _distanceTraveled += _speed * Time.deltaTime;
            Move();
            ClampHorizontalPosition();
            //Rotate();
        }
        
        if (transform.position.x >= _pathCreator.path.GetPoint(_pathCreator.path.NumPoints - 3).x && _onFinish == false)
        {
            _onFinish = true;
            RoadEnded?.Invoke();
            GetComponent<EndMover>().enabled = true;
        }
    }
}
