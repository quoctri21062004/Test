using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 5);
    }
    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }
    protected virtual void DropItemIndex(int itemIndex) 
    {
        ItemInventory itemInventory =this.inventory.Items[itemIndex];

        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.DropFromInventory(itemInventory, dropPos, dropRot);
        this.inventory.Items.Remove(itemInventory);
    }
}
