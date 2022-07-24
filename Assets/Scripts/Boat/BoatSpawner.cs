using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [SerializeField] private Boat _prefab;
    [SerializeField] private Transform _container;
    [SerializeField] private float _boundary;
    [SerializeField] private float _heigth;
    [SerializeField] private int _amount;

    private void Start()
    {
        for (int i = 0; i < _amount; i++)
        {
            Boat boat = Instantiate(_prefab);
            boat.transform.SetParent(_container);
            boat.transform.position = new Vector3(Random.Range(-_boundary, _boundary), _heigth, Random.Range(-_boundary, _boundary));
            boat.transform.position += new Vector3(_container.position.x, 0.0f, _container.position.z);
            boat.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 359), 0));
        }
    }
}
