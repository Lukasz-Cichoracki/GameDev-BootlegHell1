using System;
using UnityEngine;

public class KeyItemsTrigger : MonoBehaviour
{
    [SerializeField] private Items items;
    private void Start()
    {
        items.OnAllKeyItemsCollected += Items_OnAllKeyItemsCollected;
    }

    private void Items_OnAllKeyItemsCollected(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }
}
