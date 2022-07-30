using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _waveText;
    [SerializeField] private Slider _waveSlider;
    [SerializeField] private Image _sliderFill;
    [SerializeField] private Color[] _color;
    [SerializeField] private string[] _text;
    [SerializeField] private float _sliderValueUpgrade;

    private int _index = 0;

    private void Start()
    {
        UpdateUI();
    }

    public void IncreaseSliderValue()
    {
        _waveSlider.value += _sliderValueUpgrade;
    }

    public void ProgressUI()
    {
        _index++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _waveText.text = _text[_index];
        _waveText.color = _color[_index];
        _sliderFill.color = _color[_index];
    }
}
