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

    private Animator animator;
    private State state;

    [SerializeField] private float duration = 6f;
    private float walkableTimer;
    private float unWalkableTimer;

    private const string SINK = "Sink";
    private const string EMERGANCE = "Emergance";

    private void Start()
    {
        animator = GetComponent<Animator>();
        state = State.Walkable;
        walkableTimer = duration;
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
                    animator.SetTrigger(SINK);
                    unWalkableTimer = duration/2;
                }
                break;
            case State.Unwalkable:
                unWalkableTimer -= Time.deltaTime;
                if (unWalkableTimer <= 0)
                {
                    state = State.Walkable;
                    animator.SetTrigger(EMERGANCE);
                    walkableTimer = duration;
                }
                break;
        }
    }

}
