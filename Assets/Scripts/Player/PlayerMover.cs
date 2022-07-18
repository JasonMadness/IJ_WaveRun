using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotationOffset;
    [SerializeField] private float _horizontalBoundary;
    [SerializeField] private float _startOffset;

    private float distanceTraveled;
    private float horizontalPosition;
    private bool onFinish = false;

    private void Start()
    {
        distanceTraveled += _startOffset;
    }

    private void Move()
    {
        Vector3 moveDirection = _pathCreator.path.GetPointAtDistance(distanceTraveled);
        horizontalPosition -= Input.GetAxis("Horizontal") * Time.deltaTime;
        transform.position = new Vector3(moveDirection.x, moveDirection.y, horizontalPosition);
    }

    private void ClampHorizontalPosition()
    {
        horizontalPosition = Mathf.Clamp(horizontalPosition, -_horizontalBoundary, _horizontalBoundary);
    }

    private void Rotate()
    {
        transform.rotation = _pathCreator.path.GetRotationAtDistance(distanceTraveled) * Quaternion.Euler(_rotationOffset);
    }

    private void Update()
    {
        if (onFinish == false)
        {
            distanceTraveled += _speed * Time.deltaTime;
            Move();
            ClampHorizontalPosition();
            Rotate();
        }

        if (transform.position.x >= _pathCreator.path.GetPoint(_pathCreator.path.NumPoints - 2).x)
        {
            onFinish = true;
        }
    }
}
