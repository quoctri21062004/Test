using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : TrisMonoBehaviour 
{
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 5f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
    }
    protected virtual void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
    }
    protected virtual void FixedUpdate()
    {
        this.SpawnerSpawning();
    }
    protected virtual void SpawnerSpawning()
    {

        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < randomDelay) return;
        this.randomTimer = 0;

        Transform randPoint = this.spawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = randPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.spawnerCtrl.Spawner.RandomPrefabs();
        Transform obj = this.spawnerCtrl.Spawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentEnemies = this.spawnerCtrl.Spawner.SpawnedCount;
        return currentEnemies >= this.randomLimit;
    }

}
