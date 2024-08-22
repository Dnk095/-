using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CLickActivator _clickButton;

    private Coroutine _coroutine;
    private int _currentCount = 0;
    private bool _isActive;

    public event Action CountChanged;

    public int CurrentCount => _currentCount;

    private void Start()
    {
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
            _coroutine = StartCoroutine(Countup(0.5f));
        }
    }

    private IEnumerator Countup(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            _currentCount++;
            CountChanged?.Invoke();
            yield return wait;
        }
    }
}
