using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : TrisMonoBehaviour
{
    [SerializeField] protected DameSender dameSender;
    public DameSender DameSender { get=>dameSender;}

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get=>bulletDespawn;}

    [SerializeField] protected Transform shooter;
    public Transform Shooter { get => shooter; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameSender();
        this.LoadBulletDespawn();
    }
    
    protected virtual void LoadDameSender()
    {
        if (this.dameSender != null) return;
        this.dameSender = transform.GetComponentInChildren<DameSender>();
    }
    protected virtual void LoadBulletDespawn()
    {
        if(this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
    }
    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
