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
        _damageButton.onClick.AddListener(Damage);
        _healButton.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(Damage);
        _healButton.onClick.RemoveListener(Heal);
    }

    private void Start()
    {
        _currentPlayerHealth = 0;
    }

    private void Damage()
    {
        ChangeHealth(-_damageButtonValue);
    }

    private void Heal()
    {
        ChangeHealth(_healButtonValue);
    }

    private void ChangeHealth(float changeValue)
    {
        _currentPlayerHealth += changeValue;
        _currentPlayerHealth = Mathf.Clamp(_currentPlayerHealth, 0, _maxPlayerHealth);
        HealthChanged?.Invoke();
    }
}
