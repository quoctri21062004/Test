using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveFoward : ObjMovement
{
    [SerializeField] protected Transform moveTarget;
    protected override void FixedUpdate()
    {
        this.GetMoveTargetPosition();
        base.FixedUpdate();
    }
    protected virtual void GetMoveTargetPosition()
    {
        this.targetPosition = moveTarget.position;
        this.targetPosition.z = 0;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMovePos();
    }
    protected virtual void LoadMovePos()
    {
        if (this.moveTarget != null) return;
        this.moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ": LoadMovePos", gameObject);
    }
}
