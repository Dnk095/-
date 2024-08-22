using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = "";
    }

    private void OnEnable()
    {
        _counter.CountChanged += DrowCount;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= DrowCount;
    }
    private void DrowCount()
    {
        _text.text = _counter.CurrentCount.ToString("");
    }
}
