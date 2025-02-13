using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : PlayerAbstract
{
  public virtual void ItemPickUp(ItemPickupable itemPickupable)
    {
        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
