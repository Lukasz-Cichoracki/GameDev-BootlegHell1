using System;
using UnityEngine;


public class Items : MonoBehaviour
{
    [SerializeField] private AllItemsScriptableObject allItemsSO;

    [SerializeField] private int allKeyItemsOnLevel = 0;

    public event EventHandler OnAllKeyItemsCollected;


    private void Start()
    {
        BaseCollectingItems.OnCollect += OnCollect;
        PlayerTriggerDetection.Instance.OnNextLevel += Trigger_OnNextLevel;
        allItemsSO.crystalsCollectedOnLevel = 0;
        allItemsSO.keyItemsCollected = 0;
    }

    private void OnCollect(object sender, BaseCollectingItems.OnCollectEventArgs e)
    {
        if(e.itemType == BaseCollectingItems.Items.Crystal)
        {
            allItemsSO.crystalsCollectedOnLevel++;
        }
        if(e.itemType == BaseCollectingItems.Items.Key_Item)
        {
            allItemsSO.keyItemsCollected++;
            if (allKeyItemsOnLevel == allItemsSO.keyItemsCollected)
                OnAllKeyItemsCollected?.Invoke(this, EventArgs.Empty);
        }
    }
    
    private void Trigger_OnNextLevel(object sender, EventArgs e)
    {
        allItemsSO.allCrystalsCollected += allItemsSO.crystalsCollectedOnLevel;
        allItemsSO.crystalsCollectedOnLevel = 0;
    }

    private void OnDestroy()
    {
        BaseCollectingItems.OnCollect -= OnCollect;       
    }

}
