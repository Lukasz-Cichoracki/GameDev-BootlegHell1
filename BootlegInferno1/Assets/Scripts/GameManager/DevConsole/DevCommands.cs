using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCommands : MonoBehaviour
{
    public static DevCommands Instance { get; private set; }

    [SerializeField] private DevCommandReader reader;
    [SerializeField] private AllItemsScriptableObject itemsSO;

    public event EventHandler OnForceAllKeyItemsColected;
    public event EventHandler<OnLevelChangeEventArgs> OnLevelChange;
    public class OnLevelChangeEventArgs : EventArgs
    {
       public string levelName;
    }



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        reader.OnSubmit += Reader_OnSubmit;
    }

    private void Reader_OnSubmit(object sender, DevCommandReader.OnSubmitEventArgs e)
    {
        string command = e.command;
        string argument = e.argument;

        switch (command)
        {
            case "AddCrystals":
                if (Int32.TryParse(argument, out int crystals))
                    itemsSO.crystalsCollected += crystals;
                break;
            case "ChangeJumpForce":
                if (float.TryParse(argument, out float jumpForce))
                    Player.Instance.JumpForce = jumpForce;
                break;
            case "SetSpeed":
                 if (float.TryParse(argument, out float speed))
                    Player.Instance.MaxMovementSpeed = speed;
                break;
            case "ChangeLevel":
                OnLevelChange?.Invoke(this, new OnLevelChangeEventArgs {levelName = argument});
                break;
            case "AllKeys":
                OnForceAllKeyItemsColected?.Invoke(this, EventArgs.Empty);
                break;
            default:
                Debug.Log("Unknown Command!");
                break;

        }
    }



}
