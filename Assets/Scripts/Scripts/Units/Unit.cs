using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private void Start()
    {
        SelectUnit.Instance.units.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        SelectUnit.Instance.units.Remove(this.gameObject);
    }
}
