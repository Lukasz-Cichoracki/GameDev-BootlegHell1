using System;
using System.Collections.Generic;
using UnityEngine;


public class Items : MonoBehaviour
{
    [SerializeField] private AllItemsScriptableObject allItemsSO;


    private void Start()
    {
        BaseCollectingItems.OnCollect += OnCollect;
    }

    private void OnCollect(object sender, BaseCollectingItems.OnCollectEventArgs e)
    {
        if(e.itemType == BaseCollectingItems.Items.Crystal)
        {
            allItemsSO.crystalsCollected++;
            Debug.Log(allItemsSO.crystalsCollected);
        }
    }

    private void OnDestroy()
    {
       
    }
}
