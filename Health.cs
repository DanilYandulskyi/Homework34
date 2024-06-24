using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private UITextHealth _textHealth;
    
    private int _currentValue;

    public void Start()
    {
        _currentValue = _maxValue;

        _healthBar.UpdateBar(_currentValue, _maxValue);
        _textHealth.UpdateText(_currentValue, _maxValue);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Decrease(1);
        }       
        
        if (Input.GetMouseButtonDown(1))
        {
            Increase(1);
        }
    }

    public void Decrease(int value)
    {
        if (value < 0)
        {
            return;
        }

        if ((_currentValue -= value) <= 0)
        {
            Destroy(gameObject);
        }

        _textHealth.UpdateText(_currentValue, _maxValue);
        _healthBar.UpdateBar(_currentValue, _maxValue);
    }

    public void Increase(int value)
    {
        _currentValue += value;

        if (_currentValue >= _maxValue)
        {
            _currentValue = _maxValue;
        }

        _textHealth.UpdateText(_currentValue, _maxValue);
        _healthBar.UpdateBar(_currentValue, _maxValue);
    }
}
