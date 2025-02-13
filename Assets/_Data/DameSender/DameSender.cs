using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : TrisMonoBehaviour
{
    [SerializeField] protected float dame = 1f;

    //kiem tra da obj da co script DameReceiver
    public virtual void Send (Transform obj)
    {
        DameReceiver dameReceiver= obj.GetComponentInChildren<DameReceiver>();

        if(dameReceiver == null )
        {
            return;
        }
        this.Send(dameReceiver);
        this.CreateImpactFX();
    }

    //thuc hien tru hp va huy obj
    public virtual void Send(DameReceiver dameReceiver)
    {
        dameReceiver.Deduct(this.dame);
    }

    protected virtual void CreateImpactFX()
    {
        string fxName = this.GetImpactFX();
        Vector3 bulletHitPos = transform.position;

        Quaternion bulletHitRot = transform.rotation;
        Quaternion rotEffect = Quaternion.Euler(0, 0, -90);
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, bulletHitPos, bulletHitRot * rotEffect);
        fxImpact.gameObject.SetActive(true);
    }
    protected virtual string GetImpactFX()
    {
        return FXSpawner.impact1;
    }
}
