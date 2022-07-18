using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedBoat : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _fragments;
    [SerializeField] private float _force;

    private void Start()
    {
        foreach (Rigidbody fragment in _fragments)
        {
            float x = Random.Range(0, 1.1f);
            float z = Random.Range(0, 1.1f);
            Vector3 randomVector = Vector3.up + new Vector3(x, 0, z);
            fragment.AddForce(randomVector * _force);
            Destroy(gameObject, 3);
        }
    }
}
