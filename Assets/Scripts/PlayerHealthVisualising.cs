using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthVisualising : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerHealth _player;

    public void VisualiseHealthValue()
    {
        _slider.value = _player.CurrentPlayerHealth;
    }

    private void Start()
    {
        _slider.maxValue = _player.MaxPlayerHealth;
    }
}
