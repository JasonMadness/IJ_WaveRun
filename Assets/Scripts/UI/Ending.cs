using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject _endingPanel;
    [SerializeField] private float _targetAlpha;
    [SerializeField] private float _alphaStep;
    [SerializeField] private GameObject _smile;
    [SerializeField] private GameObject _nextButton;

    public void ShowEndingPanel()
    {
        StartCoroutine(Reveal());
    }

    private IEnumerator Reveal()
    {
        Color color = _endingPanel.GetComponent<Image>().color;

        while (color.a < _targetAlpha)
        {
            color.a += _alphaStep;
            yield return new WaitForEndOfFrame();
        }
    }
}
