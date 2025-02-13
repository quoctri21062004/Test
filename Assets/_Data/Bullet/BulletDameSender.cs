using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDameSender : DameSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }
    public override void Send(DameReceiver dameReceiver)
    {
        base.Send(dameReceiver);
        this.DestroyBullet();
    }
    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
