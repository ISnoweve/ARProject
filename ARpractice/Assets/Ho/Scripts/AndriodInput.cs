using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AndriodInput : MonoBehaviour
{
  public static AndriodInput instance;
   private AndriodInputs inputs;

    public delegate void AndriodInputHandler();
    public event AndriodInputHandler OnTouch;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            inputs = new();
            inputs.Phone.Enable();
            inputs.Phone.Touch.performed += Touched;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Touched(InputAction.CallbackContext context)
    {
        Debug.Log("Touch");
        OnTouch?.Invoke();
    }

  
  
}
