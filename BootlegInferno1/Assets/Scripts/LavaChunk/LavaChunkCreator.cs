using UnityEngine;

public class LavaChunkCreator : MonoBehaviour
{
    [SerializeField] private Transform lavaChunkSpawnTransform;
    [SerializeField] private Rigidbody2D lavaChunk;

    [SerializeField] private float timeToInstantiate = 1f;
    private float time = 0f;

    [SerializeField] private bool isChunkLaunchable=false;
    [SerializeField] private float chunkVelocity = 2f;
    private void Start()
    {
       time = 0f;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time >= timeToInstantiate)
        {
            time = 0f;
            Rigidbody2D chunk = Instantiate(lavaChunk, lavaChunkSpawnTransform);
            
            if(isChunkLaunchable)
            {
                Vector2 launchVector = new Vector2(0f,chunkVelocity);
                chunk.AddForce(launchVector);
            }
        }
    }
}
