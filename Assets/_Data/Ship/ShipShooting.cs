using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipShooting : TrisMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float shootDelay = 1f;

    private void Update()
    {
        this.IsShooting();
    }
    private void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.isShooting) return;

        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }
    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
