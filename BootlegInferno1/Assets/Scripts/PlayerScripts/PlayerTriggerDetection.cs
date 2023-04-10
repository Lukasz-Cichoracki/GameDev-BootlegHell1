using System;
using UnityEngine;

public class PlayerTriggerDetection : MonoBehaviour
{
    public static PlayerTriggerDetection Instance { get; private set; }
    
    private const string DANGER_TAG = "Danger";
    private const string CRYSTAL_TAG = "Crystal";
    
    public event EventHandler OnDeath;
    public event EventHandler OnCrystalCollected;

    private void Awake()
    {
        Instance = this;
    }

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
