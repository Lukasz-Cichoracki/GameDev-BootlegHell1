using System;
using UnityEngine;

public class PlayerTriggerDetection : MonoBehaviour
{
    public static PlayerTriggerDetection Instance { get; private set; }
    
    private const string DANGER_TAG = "Danger";
    private const string NEXT_LEVEL = "NextLevel";
    
    public event EventHandler OnDeath;
    public event EventHandler OnNextLevel;
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
        ICollectible collectible = collision.GetComponent<ICollectible>();
        if(collision.tag == DANGER_TAG)
        {
            OnDeath?.Invoke(this, EventArgs.Empty);
        }
        if(collectible!=null)
        {
            collectible.Pick();
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
