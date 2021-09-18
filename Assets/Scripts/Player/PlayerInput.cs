using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IInputControl
{
    private IInputAction[] _inputActions;

    private InputState _inputState = InputState.CanOrder;

    public enum InputState
    {
        CanOrder,
        CannotOrder
    }

    private void Start()
    {
        _inputActions = GetComponents<IInputAction>();
    }

    private void FixedUpdate()
    {
        ExecuteCommands();
    }

    private void ExecuteCommands()
    {
        if (_inputState != InputState.CanOrder) return;

        foreach (var inputAction in _inputActions)
        {
            inputAction.Action();
        }
    }

    public void SetInputState(InputState targetInputState)
    {
        _inputState = targetInputState;
    }
}