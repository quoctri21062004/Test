using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipShootingByMouse : ObjShooting
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
    protected override string BulletType()
    {
        return BulletSpawner.bulletOne;
    }
}
