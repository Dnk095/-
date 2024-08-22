using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action OnClick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button use");
            OnClick?.Invoke();
        }
    }


}
