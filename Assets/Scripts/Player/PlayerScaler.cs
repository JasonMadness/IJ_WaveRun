using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] private Vector3 _upgrage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PowerUp>(out _))
        {
            Destroy(other.gameObject);
            transform.localScale += _upgrage;
        }
    }
}
