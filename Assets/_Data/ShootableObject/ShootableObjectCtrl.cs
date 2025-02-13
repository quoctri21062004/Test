using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : TrisMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model=>model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn =>despawn;

    [SerializeField] protected ShootableObject shootableObject;
    public ShootableObject ShootableObject =>shootableObject;

    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting =>objShooting;

    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement =>objMovement;

    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget =>objLookAtTarget;

    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadObjLookAtTarget();
        this.LoadSpawner();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
    }
    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/"+this.GetObjectTypeString()+"/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObject>(resPath);
    }
    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
    }
    protected virtual void LoadObjMovement()
    {
        if (this.objMovement != null) return;
        this.objMovement = GetComponentInChildren<ObjMovement>();
    }
    protected virtual void LoadObjLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
    }
    protected abstract string GetObjectTypeString();
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>(); ;
    }
}
