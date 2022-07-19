using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerFollower))]
[RequireComponent(typeof(EndMover))]
public class ModeChanger : MonoBehaviour
{
    [SerializeField] private Player _player;

    private PlayerFollower _playerFollower;
    private EndMover _endMover;

    private void Awake()
    {
        _playerFollower = GetComponent<PlayerFollower>();
        _endMover = GetComponent<EndMover>();
    }

    private void OnEnable()
    {
        _player.Finished += OnFinished;
    }

    private void OnFinished()
    {
        _playerFollower.enabled = false;
        _endMover.enabled = true;
    }
}
