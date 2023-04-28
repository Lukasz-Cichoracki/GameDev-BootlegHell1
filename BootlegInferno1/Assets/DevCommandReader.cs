using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DevCommandReader : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Button submitButton;

    private string playerInput;
    private string[] command;

    public event EventHandler<OnSubmitEventArgs> OnSubmit;
    public class OnSubmitEventArgs : EventArgs
    {
        public string command;
        public string argument;
    }


    private void Start()
    {
        submitButton.onClick.AddListener(SubmitCommand);
    }

    private void SubmitCommand()
    {
        playerInput = input.text;
        command = playerInput.Split(' ');
        input.text = null;
        if (command.Length == 2)
            OnSubmit?.Invoke(this, new OnSubmitEventArgs { command = command[0], argument = command[1] });
    }

}
