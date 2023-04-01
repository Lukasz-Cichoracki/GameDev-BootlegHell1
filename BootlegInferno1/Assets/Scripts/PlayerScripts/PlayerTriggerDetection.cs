using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerDetection : MonoBehaviour
{
    const string DANGER_TAG = "Danger";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == DANGER_TAG)
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
