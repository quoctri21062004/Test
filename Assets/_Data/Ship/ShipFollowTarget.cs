using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShipFollowTarget : ObjMovement
{
    [SerializeField] protected Transform targetPos;
  
    protected override void FixedUpdate()
    {
        this.GetTargetPosition();
        base.FixedUpdate();
    }

    public virtual void SetTarget(Transform target)
    {
        this.targetPos = target;
    }
    protected virtual void GetTargetPosition()
    {
        this.targetPosition = this.targetPos.position;
        this.targetPosition.z = 0;
    }
    protected override void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < minDistance) return;

        base.Moving();
    }

}
