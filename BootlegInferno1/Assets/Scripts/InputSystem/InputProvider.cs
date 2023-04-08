using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputProvider : MonoBehaviour
{
    protected PlayerInputActions playerInputActions;

    protected void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }
}
