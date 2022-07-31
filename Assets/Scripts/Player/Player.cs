using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerScaler))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerScaler _playerScaler;

    public event UnityAction Finished;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerScaler = GetComponent<PlayerScaler>();
    }

    private void OnEnable()
    {
        _playerMover.RoadEnded += OnRoadEnded;
    }

    private void OnDisable()
    {
        _playerMover.RoadEnded -= OnRoadEnded;
    }

    private void OnRoadEnded()
    {
        Finished?.Invoke();
        _playerScaler.IncreaseAtEnd();
    }

    public void OnPowerUpPicked(PowerUp powerUp)
    {
        _playerScaler.IncreaseAllAxis();
        powerUp.PickedUp -= OnPowerUpPicked;
    }
}
