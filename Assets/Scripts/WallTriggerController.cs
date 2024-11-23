using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class WallTriggerController : MonoBehaviour
{
    public GameObject environmentPrefab;
    public Vector3 spawnOffset;
   

    private Vector3 previousPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trigger wall"))
        {
           GameObject spawnedObject = Instantiate(environmentPrefab, previousPosition + spawnOffset, quaternion.identity);
           previousPosition = spawnedObject.transform.position;
         
        }
    }
}
