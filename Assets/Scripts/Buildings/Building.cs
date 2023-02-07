using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private BuildingsData _data;
    private Transform _position;
    private int _currHealth;

    public Building(BuildingsData data)
    {
        _data = data;
        _currHealth = data.Health;

        GameObject g = GameObject.Instantiate(
            Resources.Load($"Prefabs/Buildings/{_data.Type}")
        ) as GameObject;
        _position = g.transform;
    }

    public void SetPosition(Vector3 position)
    {
        _position.position = position;
    }

    public string Code { get => _data.Type; }
    public Transform Transform { get => _position; }
    public int HP { get => _currHealth; set => _currHealth = value; }
    public int MaxHP { get => _data.Health; }
    public int DataIndex
    {
        get
        {
            for (int i = 0; i < Globals.Building_Data.Length; i++)
            {
                if (Globals.Building_Data[i].Type == _data.Type)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
    

