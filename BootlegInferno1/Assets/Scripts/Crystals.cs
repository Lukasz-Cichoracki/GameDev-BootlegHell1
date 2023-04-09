using System;
using UnityEngine;


public class Crystals : MonoBehaviour
{
    [SerializeField] private PlayerTriggerDetection playerTriggerDetection;

    private int allCrystals = 0;

    public event EventHandler CrystalsUpdate;
    public class CrystalsUpdateEventArgs : EventArgs
    {
        public int crystals;
    }
    
    private void Start()
    {
        playerTriggerDetection.OnCrystalCollected += CrystalsCollected_OnCrystalCollected;
    }

    private void CrystalsCollected_OnCrystalCollected(object sender, System.EventArgs e)
    {
        allCrystals++;
        CrystalsUpdate?.Invoke(this, new CrystalsUpdateEventArgs { crystals = allCrystals });
    }
}
