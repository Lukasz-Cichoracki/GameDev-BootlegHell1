using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCrystalls : MonoBehaviour
{
    [SerializeField] private PlayerTriggerDetection playerTriggerDetection;
    private void Start()
    {
        playerTriggerDetection.OnCrystalCollected += PlayerTriggerDetection_OnCrystalCollected;
    }

    private void PlayerTriggerDetection_OnCrystalCollected(object sender, System.EventArgs e)
    {      
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
      playerTriggerDetection.OnCrystalCollected -= PlayerTriggerDetection_OnCrystalCollected;
    }
}
