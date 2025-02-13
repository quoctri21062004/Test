using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DameReceiver : TrisMonoBehaviour
{
    [SerializeField] protected float hp = 1f;
    [SerializeField] protected float maxHp = 2f;
    [SerializeField] protected bool isDead = false;

    protected override void Start()
    {
        base.Start();
       this.Reborn();
    }
    public virtual void Reborn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }
    public virtual void Add(float add)
    {
        this.hp += add;
        if (this.hp > maxHp)
        {
            this.hp = this.maxHp;
        }
    }
    public virtual void Deduct(float deduct)
    {
        this.hp -= deduct;
        if (this.hp < 0)
        {
            this.hp = 0;
        }
        this.CheckIsDead();
    }
    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected abstract void OnDead();
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
}
