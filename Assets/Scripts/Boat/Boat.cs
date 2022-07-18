using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private GameObject _fracturedBoat;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMover>(out _))
        {
            GameObject fracturedBoat = Instantiate(_fracturedBoat);
            fracturedBoat.transform.position = transform.position;
            fracturedBoat.transform.rotation = transform.rotation;
            Destroy(gameObject);
        }
    }
}
