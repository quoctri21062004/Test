using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 15f;
    }
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }
}
