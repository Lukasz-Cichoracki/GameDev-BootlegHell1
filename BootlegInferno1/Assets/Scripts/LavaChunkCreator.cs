using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LavaChunkCreator : MonoBehaviour
{
    [SerializeField] private Transform lavaChunkSpawnTransform;
    [SerializeField] private GameObject lavaChunk;

    [SerializeField] private float timeToInstantiate = 1f;
    private float time = 0f;

    private void Start()
    {
       time = 0f;
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time >= timeToInstantiate)
        {
            time = 0f;
            Instantiate(lavaChunk, lavaChunkSpawnTransform);
        }
    }
}
