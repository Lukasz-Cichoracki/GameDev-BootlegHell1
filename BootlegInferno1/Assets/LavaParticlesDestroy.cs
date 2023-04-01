using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaParticlesDestroy : MonoBehaviour
{
    [SerializeField] private float maxTimeToDestroy = 1f;
    private float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= maxTimeToDestroy)
            Destroy(this.gameObject);
    }
}
