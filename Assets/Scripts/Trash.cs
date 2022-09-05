using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trash : MonoBehaviour
{
    [SerializeField] private int yield = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != GameManager.Instance.Player) return;
        GameManager.Instance.CollectTrash(yield);
        Destroy(gameObject);
    }
}
