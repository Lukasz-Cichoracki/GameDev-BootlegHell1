using System;
using UnityEngine;

public class CollectingKeyItems : BaseCollectingItems
{
    public override void Pick()
    {
        Destroy(this.gameObject);
        OnCollect?.Invoke(this, new OnCollectEventArgs { itemType = Items.Key_Item });
    }
}

