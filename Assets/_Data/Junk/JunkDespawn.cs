using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    [SerializeField] protected JunkCtrl junkCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkCtrl>();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 15f;
    }
    protected override void DespawnObject()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
        //junkCtrl.JunkSpawner.Despawn(transform.parent);
    }
}
