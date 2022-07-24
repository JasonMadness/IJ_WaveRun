using System.Net.NetworkInformation;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private Rigidbody[] _pieces;

    private void Start()
    {
        _pieces = GetComponentsInChildren<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Boat>(out _))
        {
            Debug.Log("!");
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            
            foreach (Rigidbody piece in _pieces)
            {
                piece.useGravity = true;
                piece.AddForce((Vector3.up + Random.insideUnitSphere) * 3, ForceMode.Impulse);
            }

            Destroy(gameObject, 3f);
        }
    }
}
