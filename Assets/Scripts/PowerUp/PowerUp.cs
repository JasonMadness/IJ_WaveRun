using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _heigth;
    [SerializeField] private ParticleSystem _splash;
    
    private Transform _particlesContainer;

    public event UnityAction<PowerUp> PickedUp;

    private void Start()
    {
        DropToGround();
    }

    public void Init(Transform particlesContainer)
    {
        _particlesContainer = particlesContainer;
    }

    private void DropToGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out RaycastHit raycastHit);
        transform.position = raycastHit.point + new Vector3(0.0f, _heigth, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PickedUp?.Invoke(this);
        ParticleSystem splash = Instantiate(_splash, transform.position, transform.rotation);
        splash.transform.SetParent(_particlesContainer);
        Destroy(splash.gameObject, 2f);
        Destroy(gameObject);
    }
}
