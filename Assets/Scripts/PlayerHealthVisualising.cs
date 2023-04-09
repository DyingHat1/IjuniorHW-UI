using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthVisualising : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private float _deltaChangeSliderValue;

    private bool _coroutineIsOn;
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
        _coroutineIsOn = false;
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
        _coroutineIsOn = true;

        while (_slider.value != _player.CurrentPlayerHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentPlayerHealth, _deltaChangeSliderValue);
            yield return null;
        }

        _coroutineIsOn = false;
    }

    private void CheckCoroutine()
    {
        if (_coroutineIsOn)
        {
            _coroutineIsOn = false;
            StopCoroutine(_healthVisualisation);
        }
    }
}
