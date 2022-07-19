using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleUpgrade;
    [SerializeField] private float _scaleUpdateSpeed;
    
    private Vector3 _targetScale;

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
