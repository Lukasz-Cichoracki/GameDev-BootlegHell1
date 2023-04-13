using UnityEngine;

public class CollectingCrystals : MonoBehaviour
{
    private Collider2D crystalCollider;
    private void Start()
    {
        crystalCollider = GetComponent<Collider2D>();
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
