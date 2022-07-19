using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleUpgrade; 
    
    public void OnPowerUpPicked(PowerUp powerUp)
    {
        transform.localScale += _scaleUpgrade;
        powerUp.PickedUp -= OnPowerUpPicked;
    }
}
