using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : TrisMonoBehaviour
{
    [SerializeField] protected ItemDropDespawn itemDropDespawn;
    public ItemDropDespawn ItemDropDespawn => itemDropDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDropDespawn();
        this.LoadInventory();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }

    protected virtual void LoadItemDropDespawn()
    {
        if (this.itemDropDespawn != null) return;
        this.itemDropDespawn = transform.GetComponentInChildren<ItemDropDespawn>();
        Debug.Log(transform.name + " :LoadItemDropDespawn", gameObject);
    }
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
    }
    protected virtual void LoadInventory()
    {
        if (itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.ResetItem();

    }
    protected virtual void ResetItem()
    {
        this.ItemInventory.itemCount = 1;
        this.ItemInventory.upgradeLevel = 0;
    }
}
