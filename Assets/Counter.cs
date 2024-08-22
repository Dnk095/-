using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;

    private int _currentCount = 0;

    private Coroutine _coroutine;

    private bool _isActive;

    private void Start()
    {
        _text.text = "";
        _isActive = false;
    }

    private void OnEnable()
    {
        _button.OnClick += EventReaction;
    }

    private void OnDisable()
    {
        _button.OnClick -= EventReaction;
    }

    private void EventReaction()
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
            DispplayCountUp(_currentCount);
            yield return wait;
        }
    }

    private void DispplayCountUp(int count)
    {
        _text.text = count.ToString("");
    }
}
