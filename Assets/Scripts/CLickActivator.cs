using System;
using UnityEngine;

public class CLickActivator : MonoBehaviour
{
    public event Action Clicked;

    private int _mouseButtonNumber = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonNumber))
            Clicked?.Invoke();
    }
}
