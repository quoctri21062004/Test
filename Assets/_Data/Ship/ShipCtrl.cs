using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AbilityObjectCtrl
{
    private static ShipCtrl instance;
    public ShipCtrl Instance => instance;

    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void Awake()
    {
        base.Awake();
        if (ShipCtrl.instance != null)
        {
            Debug.LogError("Only 1 ShipCtrl allow to exist");
        }
        ShipCtrl.instance = this;

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
        Debug.Log(transform.name +" :LoadInventory"+gameObject);
    }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }
}
