using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class ObjShooting : TrisMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float shootDelay = 0.3f;
    private void Update()
    {
        this.IsShooting();
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }
    protected abstract string BulletType();
    
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        Transform newBullet = BulletSpawner.Instance.Spawn(BulletType(), spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }
    protected abstract bool IsShooting();
  
}
