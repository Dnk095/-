using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CLickActivator _clickButton;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private int _currentCount = 0;
    private bool _isActive;
    private float _delay=0.5f;

    public event Action CountChanged;

    public int CurrentCount => _currentCount;

    private void Start()
    {
        _wait = new WaitForSeconds(_delay);
        _isActive = false;
    }

    private void OnEnable()
    {
        _clickButton.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _clickButton.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        if (_isActive)
        {
            _isActive = false;

            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
        else
        {
            _isActive = true;
            _coroutine = StartCoroutine(Countup());
        }
    }

    private IEnumerator Countup()
    {
        while (true)
        {
            _currentCount++;
            CountChanged?.Invoke();
            yield return _wait;
        }
    }
}
