using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.currentFuel = GameManager.Instance.maxFuel;
    }
}
