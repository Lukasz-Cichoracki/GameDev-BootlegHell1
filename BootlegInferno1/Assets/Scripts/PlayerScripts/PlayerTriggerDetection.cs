using System;
using UnityEngine;

public class PlayerTriggerDetection : MonoBehaviour
{
    public static PlayerTriggerDetection Instance { get; private set; }
    
    private const string DANGER_TAG = "Danger";
    private const string CRYSTAL_TAG = "Crystal";
    private const string NEXT_LEVEL = "NextLevel";
    
    public event EventHandler OnDeath;
    public event EventHandler OnNextLevel;
    public event EventHandler<OnCrystalCollectedEventArgs> OnCrystalCollected;
    public class OnCrystalCollectedEventArgs : EventArgs
    {
        public Collider2D collider;
    }

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
            OnCrystalCollected?.Invoke(this, new OnCrystalCollectedEventArgs { collider = collision});
        }
        if(collision.tag == NEXT_LEVEL)
        {
            OnNextLevel?.Invoke(this, EventArgs.Empty);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == DANGER_TAG)
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
    }

}
