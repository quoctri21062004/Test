using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    [SerializeField] protected JunkSpaawnerCtrl junkSpawnerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpaawnerCtrl>();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 15f;
    }
    public override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
        //junkCtrl.JunkSpawner.Despawn(transform.parent);
    }
}
