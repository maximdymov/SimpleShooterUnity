using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{
    public event EventHandler PlayerDetected;
    public event Action PlayerRan;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            PlayerDetected?.Invoke(other.transform.position, null);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            PlayerRan?.Invoke();
    }
}
