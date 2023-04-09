using System;
using UnityEngine;

public class PlayerTriggerDetection : MonoBehaviour
{
    const string DANGER_TAG = "Danger";
    const string CRYSTAL_TAG = "Crystal";
    
    public event EventHandler OnDeath;
    public event EventHandler OnCrystalCollected;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == DANGER_TAG)
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
        if(collision.tag == CRYSTAL_TAG)
        {
            OnCrystalCollected?.Invoke(this, EventArgs.Empty);
        }
    }
}
