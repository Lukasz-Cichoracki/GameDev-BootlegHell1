using System;
using UnityEngine;

public class PlayerTriggerDetection : MonoBehaviour
{
    const string DANGER_TAG = "Danger";
    public event EventHandler OnDeath;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == DANGER_TAG)
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }
}
