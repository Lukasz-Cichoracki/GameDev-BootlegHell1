using System;
using UnityEngine;

public abstract class BaseCollectingItems : MonoBehaviour, ICollectible
{
    public enum Items
    {
        Crystal,
        Key_Item,
    }

    public static EventHandler<OnCollectEventArgs> OnCollect;

    public class OnCollectEventArgs : EventArgs
    {
        public Items itemType;
    }

    public virtual void Pick()
    {
    
    }
}
