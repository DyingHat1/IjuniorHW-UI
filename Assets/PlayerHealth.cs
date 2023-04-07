using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxPlayerHealth;
    [SerializeField] private Slider _slider;

    private WaitForEndOfFrame _wait;
    private bool _isCoroutineOn;
    private float _currentPlayerHealth;
    private float _changeValue;
    private float _deltaChangeValue;
    private float _targetHealth;

    private void Start()
    {
        _wait = new WaitForEndOfFrame();
        _isCoroutineOn = false;
        _deltaChangeValue = 0.5f;
        _slider.maxValue = _maxPlayerHealth;
        _currentPlayerHealth = 0;
    }

    private void Update()
    {
        _slider.value = _currentPlayerHealth;
    }

    public void ButtonClicked(float changeValue)
    {
        _changeValue = changeValue;
        _targetHealth = _currentPlayerHealth + _changeValue;

        if (_targetHealth < 0)
            _targetHealth = 0;
        else if (_targetHealth > _maxPlayerHealth)
            _targetHealth = _maxPlayerHealth;

        StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        if (_isCoroutineOn)
        {
            StopAllCoroutines();
            _isCoroutineOn = false;
        }

        _isCoroutineOn = true;

        while (_currentPlayerHealth != _targetHealth)
        {
            _currentPlayerHealth = Mathf.MoveTowards(_currentPlayerHealth, _targetHealth, _deltaChangeValue);
            yield return _wait;
        }

        _isCoroutineOn = false;
    }
}
