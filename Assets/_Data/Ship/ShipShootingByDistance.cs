using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipShootingByDistance : ObjShooting
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance =Mathf.Infinity;
    [SerializeField] protected float shootDistance = 4f;

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override bool IsShooting()
    {
        distance = Vector3.Distance(transform.position, target.position);

        this.isShooting = distance<this.shootDistance;
        return this.isShooting;
    }
    protected override string BulletType()
    {
        return BulletSpawner.bulletTwo;
    }
}
