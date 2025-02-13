using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtPlayer: ObjLookAtTarget
{
    [SerializeField] protected GameObject player;
    protected override void FixedUpdate()
    {
        this.GetPlayerPosition();
        base.FixedUpdate();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipPos();
    }
    protected virtual void LoadShipPos()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ": LoadMovePos", gameObject);
    }
    protected virtual void GetPlayerPosition()
    {
        this.targetPosition = this.player.transform.position;
        this.targetPosition.z = 0;
    }
}
