using Unity.VisualScripting;
using UnityEngine;

public class LavaChunkDestroy: MonoBehaviour
{
    [SerializeField] private Transform lavaParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(lavaParticles.gameObject, new Vector3(this.transform.position.x,this.transform.position.y+.5f,1f), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
