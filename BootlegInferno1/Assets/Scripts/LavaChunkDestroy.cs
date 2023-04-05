using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaChunkDestroy: MonoBehaviour
{
    [SerializeField] private GameObject lavaParticles;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
