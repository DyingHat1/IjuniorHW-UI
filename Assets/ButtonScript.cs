using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private float _changeValue;

    public void OnButtonClick()
    {
        _player.ButtonClicked(_changeValue);
    }
}
