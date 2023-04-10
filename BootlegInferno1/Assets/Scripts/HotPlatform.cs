using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotPlatform : MonoBehaviour
{
    private enum State
    {
        Walkable,
        Unwalkable,
    }

    private Transform platform;
    private State state;

    private const string UNTAGGED = "Untagged";
    private const string DANGER = "Danger";

    private float walkableTimer = 3f;
    private float unWalkableTimer = 3f;

    private void Start()
    {
       
        state = State.Walkable;
        platform = GetComponent<Transform>();
    }

    private void Update()
    {
        switch(state)
        { 
            case State.Walkable:
                walkableTimer -= Time.deltaTime;
                if(walkableTimer <= 0)
                {
                    state = State.Unwalkable;
                    transform.tag = DANGER;
                    unWalkableTimer = 10f;
                    Debug.Log("Changed to UnWalkable");
                }
                break;
            case State.Unwalkable:
                unWalkableTimer -= Time.deltaTime;
                if (unWalkableTimer <= 0)
                {
                    state = State.Walkable;
                    transform.tag = UNTAGGED;
                    walkableTimer = 10f;
                    Debug.Log("Changed to Walkable");
                }
                break;
        }
    }

}
