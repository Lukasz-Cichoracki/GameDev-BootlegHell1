using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCrystalls : MonoBehaviour
{
    [SerializeField] private Collider2D crystalCollider;
    private void Start()
    {
       PlayerTriggerDetection.Instance.OnCrystalCollected += PlayerTriggerDetection_OnCrystalCollected;
    }

    private void PlayerTriggerDetection_OnCrystalCollected(object sender, PlayerTriggerDetection.OnCrystalCollectedEventArgs e)
    {      
        if(e.collider == crystalCollider)
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
      PlayerTriggerDetection.Instance.OnCrystalCollected -= PlayerTriggerDetection_OnCrystalCollected;
    }
}
