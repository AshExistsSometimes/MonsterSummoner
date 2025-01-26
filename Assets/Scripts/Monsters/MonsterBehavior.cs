using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public SO_Monster Monster_Data;

    public int SummonedAmount = 0;// Will increase every time the monster is summoned

    public bool IsDiscovered = false;

    private void Update()
    {
        if (SummonedAmount > 0)
        {
            IsDiscovered = true;
        }
    }
}
