using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private float _damageButtonValue;
    [SerializeField] private float _healButtonValue;
    [SerializeField] private float _maxPlayerHealth;

    public event UnityAction HealthChanged;
    private float _currentPlayerHealth;

    public float MaxPlayerHealth => _maxPlayerHealth;
    public float CurrentPlayerHealth => _currentPlayerHealth;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(OnDamageButtonClick);
        _healButton.onClick.AddListener(OnHealButtonClick);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(OnDamageButtonClick);
        _healButton.onClick.RemoveListener(OnHealButtonClick);
    }

    private void Start()
    {
        _currentPlayerHealth = 0;
    }

    private void OnDamageButtonClick()
    {
        ChangeHealth(-_damageButtonValue);
    }

    private void OnHealButtonClick()
    {
        ChangeHealth(_healButtonValue);
    }

    private void ChangeHealth(float changeValue)
    {
        _currentPlayerHealth += changeValue;

        if (_currentPlayerHealth < 0)
            _currentPlayerHealth = 0;
        else if (_currentPlayerHealth > _maxPlayerHealth)
            _currentPlayerHealth = _maxPlayerHealth;

        HealthChanged?.Invoke();
    }
}
