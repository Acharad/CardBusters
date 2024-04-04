using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedInstantiator : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float delay;
    [SerializeField] private GameObject prefab;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        if(prefab == null) yield break;
        
        Instantiate(prefab);
    }
}
