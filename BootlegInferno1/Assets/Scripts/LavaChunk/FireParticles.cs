using UnityEngine;

public class FireParticles : MonoBehaviour
{

    [SerializeField] private float timeToDestroy = 2f;
    private float time = 0f;
    private void Update()
    {
    
        time += Time.deltaTime;
        if (time >= timeToDestroy)
            Destroy(this.gameObject);
    }
}
