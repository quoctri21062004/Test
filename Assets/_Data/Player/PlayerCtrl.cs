using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : TrisMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected ShipCtrl currentShip ;
    public ShipCtrl CurrentShip => currentShip ;

    [SerializeField] protected PlayerPickUp playerPickUp ;
    public PlayerPickUp PlayerPickUp => playerPickUp ;

    protected override void Awake()
    {
        base.Awake();
        if(PlayerCtrl.instance != null )
        {
            Debug.LogError("Only 1 PlayerCtrl allow to exist");
        }
        PlayerCtrl.instance = this ;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickUp != null) return;
        this.playerPickUp=transform.GetComponentInChildren<PlayerPickUp>();
    }
}
