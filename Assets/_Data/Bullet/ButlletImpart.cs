using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButlletImpart : BulletAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.bulletCtrl.Shooter) return;

        this.bulletCtrl.DameSender.Send(other.transform);
      //this.CreateImpactFX();

    }
    //protected virtual void CreateImpactFX()
    //{
    //    string fxName = this.GetImpactFX();
    //    Vector3 bulletHitPos = transform.position;

    //    Quaternion bulletHitRot = transform.rotation;
    //    Quaternion rotEffect = Quaternion.Euler(0, 0, -90);
    //    Transform fxImpact = FXSpawner.Instance.Spawn(fxName,bulletHitPos,bulletHitRot*rotEffect);
    //    fxImpact.gameObject.SetActive(true);
    //}
    //protected virtual string GetImpactFX()
    //{
    //    return FXSpawner.impact1;
    //}
}
