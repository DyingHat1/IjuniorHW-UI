using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent _visualise;
    [SerializeField] private float _maxPlayerHealth;

    private WaitForEndOfFrame _wait;
    private bool _isCoroutineOn;
    private float _currentPlayerHealth;
    private float _changeValue;
    private float _deltaChangeValue;
    private float _targetHealth;

    public float MaxPlayerHealth => _maxPlayerHealth;
    public float CurrentPlayerHealth => _currentPlayerHealth;

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

    private void Start()
    {
        _wait = new WaitForEndOfFrame();
        _isCoroutineOn = false;
        _deltaChangeValue = 0.5f;
        _currentPlayerHealth = 0;
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
            _visualise.Invoke();
            yield return _wait;
        }

        _isCoroutineOn = false;
    }
}
