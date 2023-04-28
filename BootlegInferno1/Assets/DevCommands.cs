using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCommands : MonoBehaviour
{
    public static DevCommands Instance { get; private set; }

    [SerializeField] private DevCommandReader reader;
    [SerializeField] private AllItemsScriptableObject itemsSO;

    public event EventHandler<OnLevelChangeEventArgs> OnLevelChange;
    public class OnLevelChangeEventArgs : EventArgs
    {
       public string levelName;
    }

    private string command;



    private void Start()
    {
        Instance = this;
        reader.OnSubmit += Reader_OnSubmit;
    }

    private void Reader_OnSubmit(object sender, DevCommandReader.OnSubmitEventArgs e)
    {
        command = e.command;

        switch (command)
        {
            case "AddCrystals":
                if (Int32.TryParse(e.argument, out int crystals))
                    itemsSO.crystalsCollected += crystals;
                break;
            case "ChangeJumpForce":
                if (float.TryParse(e.argument, out float jumpForce))
                    Player.Instance.JumpForce = jumpForce;
                break;
            case "SetSpeed":
                 if (float.TryParse(e.argument, out float speed))
                    Player.Instance.MaxMovementSpeed = speed;
                break;
            case "ChangeLevel":
                OnLevelChange?.Invoke(this, new OnLevelChangeEventArgs {levelName = e.argument });
                break;
            default:
                Debug.Log("Unknown Command!");
                break;

        }
    }



}
