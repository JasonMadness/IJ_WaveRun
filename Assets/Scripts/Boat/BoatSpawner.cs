using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _boundary;
    [SerializeField] private float _heigth;
    [SerializeField] private int _amount;

    private void Start()
    {
        for (int i = 0; i < _amount; i++)
        {
            GameObject boat = Instantiate(_prefab);
            boat.transform.position = new Vector3(Random.Range(-_boundary, _boundary), _heigth, Random.Range(-_boundary, _boundary));
            boat.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 359), 0));
        }
    }
}
