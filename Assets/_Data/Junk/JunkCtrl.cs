using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : TrisMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get=> junkDespawn; }

    [SerializeField] protected ShootableObject shootableObject;
    public ShootableObject ShootableObject { get => shootableObject; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }    
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name+": LoadModel",gameObject);
    }
    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
    }
    protected virtual void LoadJunkSO()
    {
        if(this.shootableObject != null) return;
        string resPath = "ShootableObject/JunkSO/" + transform.name;
        this.shootableObject = Resources.Load<ShootableObject>(resPath);
        Debug.Log(transform.name+" LoadJunkSO"+resPath,gameObject);
    }
}
