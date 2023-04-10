using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCrystalls : MonoBehaviour
{
    
    private void Start()
    {
       PlayerTriggerDetection.Instance.OnCrystalCollected += PlayerTriggerDetection_OnCrystalCollected;
    }

    private void PlayerTriggerDetection_OnCrystalCollected(object sender, System.EventArgs e)
    {      
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
      PlayerTriggerDetection.Instance.OnCrystalCollected -= PlayerTriggerDetection_OnCrystalCollected;
    }
}
