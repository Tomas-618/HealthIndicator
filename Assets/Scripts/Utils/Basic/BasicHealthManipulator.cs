using System;
using TMPro;
using UnityEngine;

public abstract class BasicHealthManipulator : MonoBehaviour
{
    [SerializeField] private Health _entity;
    [SerializeField] private InteractableButton _interactableButton;

    private float _value;

    public Health Entity => _entity;

    public float Value => _value;

    private void OnEnable()
    {
        _interactableButton.OnClick += OnClick;
    }

    private void OnDisable()
    {
        _interactableButton.OnClick += OnClick;
    }

    public void SetValue(string value)
    {
        if ((value ?? throw new ArgumentNullException(value)) == string.Empty)
        {
            _value = 0;

            return;
        }

        float.TryParse(value, out _value);
    }

    protected abstract void OnClick();
}
