using UnityEngine;

public class CollectingCrystals : BaseCollectingItems
{
    public override void Pick()
    {
        Destroy(this.gameObject);
        OnCollect?.Invoke(this, new OnCollectEventArgs { itemType = Items.Crystal });
    }
}
