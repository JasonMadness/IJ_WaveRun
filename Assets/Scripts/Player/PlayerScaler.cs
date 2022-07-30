using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaler : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleUpgrade;
    [SerializeField] private float _scaleUpdateSpeed;
    [SerializeField] private Vector3 _endScaleUpgrade;
    [SerializeField] private float _endUpgradeDelay;
    [SerializeField] private float _endUpgradeCount;
    [SerializeField] private float _endUpgradeInterval;

    private Vector3 _targetScale;
    private bool _roadEnded = false;

    private void Start()
    {
        _targetScale = transform.localScale;
    }

    public void IncreaseAllAxis()
    {
        _targetScale += _scaleUpgrade;
    }

    public void IncreaseAtEnd()
    {
        _roadEnded = true;
        StartCoroutine(Increase());
    }

    private IEnumerator Increase()
    {
        yield return new WaitForSeconds(_endUpgradeDelay);
        Vector3 scale = transform.localScale;
        WaitForSeconds delay = new WaitForSeconds(_endUpgradeInterval);

        for (int i = 0; i < _endUpgradeCount; i++)
        {
            scale += _endScaleUpgrade;
            transform.localScale = scale;
            yield return delay;
        }
    }

    private void Update()
    {
        if (_roadEnded == false)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, _scaleUpdateSpeed * Time.deltaTime);
        }
    }
}
