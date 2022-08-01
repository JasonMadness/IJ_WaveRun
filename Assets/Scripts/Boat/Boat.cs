using System.Net.NetworkInformation;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _destroyDelay;

    private Rigidbody[] _pieces;

    private void Start()
    {
        _pieces = GetComponentsInChildren<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            gameObject.GetComponent<Collider>().enabled = false;

            foreach (Rigidbody piece in _pieces)
            {
                piece.useGravity = true;
                piece.AddForce((Vector3.up + Random.insideUnitSphere) * _explosionForce, ForceMode.Impulse);
            }

            Destroy(gameObject, _destroyDelay);
        }
    }
}
