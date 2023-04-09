using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthVisualising : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private float _deltaChangeSliderValue;

    private bool _isCoroutineOn;
    private Coroutine _healthVisualisation;

    private void OnEnable()
    {
        _player.HealthChanged += VisualiseHealthValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= VisualiseHealthValue;
    }

    private void Start()
    {
        _isCoroutineOn = false;
        _slider.value = _player.CurrentPlayerHealth;
        _slider.maxValue = _player.MaxPlayerHealth;
    }

    private void VisualiseHealthValue()
    {
        CheckCoroutine();
        _healthVisualisation = StartCoroutine(HealthVisualisation());
    }

    private IEnumerator HealthVisualisation()
    {
        _isCoroutineOn = true;

        while (_slider.value != _player.CurrentPlayerHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentPlayerHealth, _deltaChangeSliderValue);
            yield return null;
        }

        _isCoroutineOn = false;
    }

    private void CheckCoroutine()
    {
        if (_isCoroutineOn)
        {
            _isCoroutineOn = false;
            StopCoroutine(_healthVisualisation);
        }
    }
}
