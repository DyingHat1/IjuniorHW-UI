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
        StartCoroutine(HealthVisualisation());
    }

    private IEnumerator HealthVisualisation()
    {
        if (_coroutineIsOn)
        {
            StopAllCoroutines();
            _coroutineIsOn = false;
            VisualiseHealthValue();
        }
        else
        {
            _coroutineIsOn = true;

            while (_slider.value != _player.CurrentPlayerHealth)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentPlayerHealth, _deltaChangeSliderValue);
                yield return null;
            }

            _coroutineIsOn = false;
        }
    }
}
