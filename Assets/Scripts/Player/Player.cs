using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleUpgrade;
    [SerializeField] private float _scaleUpdateSpeed;

    private PlayerMover _playerMover;
    private Vector3 _targetScale;

    public event UnityAction Finished;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerMover.RoadEnded += OnRoadEnded;
    }

    private void OnDisable()
    {
        _playerMover.RoadEnded -= OnRoadEnded;
    }

    private void OnRoadEnded()
    {
        Finished?.Invoke();
    }

    private void Start()
    {
        _targetScale = transform.localScale;
    }

    public void OnPowerUpPicked(PowerUp powerUp)
    {
        _targetScale += _scaleUpgrade;
        powerUp.PickedUp -= OnPowerUpPicked;
    }

    private void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, _scaleUpdateSpeed * Time.deltaTime);
    }
}
