using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private GameObject _fracturedBoat;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Boat>(out _))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            Destroy(gameObject);
        }
    }
}
