using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private Ending _ending;
    [SerializeField] private Text _waveText;
    [SerializeField] private Slider _waveSlider;
    [SerializeField] private Image _sliderFill;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerScaler _playerScaler;
    [SerializeField] private TMP_Text _coefficient;
    [SerializeField] private Color[] _color;
    [SerializeField] private string[] _text;
    [SerializeField] private float _sliderValueUpgrade;

    private int _index = 0;
    private float _stageCount = 4;

    private void Start()
    {
        UpdateUI();
    }

    private void OnEnable()
    {
        _playerScaler.Scaled += OnPlayerScaled;
    }

    private void OnDisable()
    {
        _playerScaler.Scaled -= OnPlayerScaled;
    }

    public void IncreaseSliderValue()
    {
        _waveSlider.value += _sliderValueUpgrade;


        if (_waveSlider.value > 1)
        {
            _waveSlider.value = 1;
        }

        if (_waveSlider.value > (_index + 1) / _stageCount)
        {
            ProgressUI();
        }
    }

    private void ProgressUI()
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

    private void OnPlayerScaled(int coefficient)
    {
        if (coefficient != 0)
        {
            _coefficient.text = $"x{coefficient}";
        }
        else
        {
            _coefficient.text = string.Empty;
        }
    }

    public void OnPowerUpPicked(PowerUp powerUp)
    {
        IncreaseSliderValue();
        powerUp.PickedUp -= OnPowerUpPicked;
    }
}
