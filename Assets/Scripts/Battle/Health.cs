using System;
using UnityEngine;

public class Health : MonoBehaviour, IReadOnlyHealth, IReadOnlyHealthEvents
{
    [SerializeField, Min(1)] private float _maxValue;

    private float _value;

    public event Action Died;

    public event Action<float> Damaged;

    public event Action<float> OnHealing;

    public float MaxValue => _maxValue;

    public float Value
    {
        get => _value;
        private set
        {
            if (value >= _maxValue)
                _value = _maxValue;
            else if (value <= 0)
                _value = 0;
            else
                _value = value;
        }
    }

    private void Reset() =>
        _maxValue = 100;

    private void Start() =>
        _value = _maxValue;

    public void Increase(in float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(value.ToString());

        Value += value;
        OnHealing?.Invoke(Value);
    }

    public void TakeDamage(in float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(value.ToString());

        Value -= value;

        if (Value <= 0)
        {
            Died?.Invoke();

            return;
        }

        Damaged?.Invoke(Value);
    }
}
