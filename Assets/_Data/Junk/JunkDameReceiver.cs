using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDameReceiver : DameReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkDameReceiver();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected virtual void LoadJunkDameReceiver()
    {
        if (junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name+" :LoadJunkDameReceiver",gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.junkCtrl.JunkDespawn.DespawnObject();
      
    }
    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos= transform.position;
        Quaternion dropRot= transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList,dropPos, dropRot);
    }
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }
    public override void Reborn()
    {
        this.maxHp = this.junkCtrl.ShootableObject.hpMax;
        base.Reborn();
    }
}
