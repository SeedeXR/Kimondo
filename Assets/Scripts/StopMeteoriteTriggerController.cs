using System;
using UnityEngine;
using UnityEngine.Events;

public class StopMeteoriteTriggerController : MonoBehaviour
{
    public MeteoriteController meteoriteController;
    public UnityEvent _onTriggerEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            meteoriteController.OnStopSpawning();
            _onTriggerEvent.Invoke();
        }
    }
}
