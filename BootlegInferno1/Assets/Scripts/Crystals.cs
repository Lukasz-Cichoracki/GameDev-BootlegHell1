using System;
using UnityEngine;


public class Crystals : MonoBehaviour
{
    
    private int allCrystals = 0;

    public event EventHandler<CrystalsUpdateEventArgs> CrystalsUpdate;
    public class CrystalsUpdateEventArgs : EventArgs
    {
        public int crystals;
    }

    private void Start()
    {
        PlayerTriggerDetection.Instance.OnCrystalCollected += CrystalsCollected_OnCrystalCollected;
    }

    private void CrystalsCollected_OnCrystalCollected(object sender, EventArgs e)
    {
        allCrystals++;
        CrystalsUpdate?.Invoke(this, new CrystalsUpdateEventArgs { crystals = allCrystals });
    }

    private void OnDestroy()
    {
        PlayerTriggerDetection.Instance.OnCrystalCollected -= CrystalsCollected_OnCrystalCollected;
    }
}
