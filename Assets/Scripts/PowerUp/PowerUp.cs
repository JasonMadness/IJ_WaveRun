using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _heigth;

    private void Start()
    {
        DropToGround();
    }

    private void DropToGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out RaycastHit raycastHit);
        transform.position = raycastHit.point + new Vector3(0.0f, _heigth, 0.0f);
    }
}
