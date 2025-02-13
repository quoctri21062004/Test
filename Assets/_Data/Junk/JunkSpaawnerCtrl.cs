using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpaawnerCtrl : TrisMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; }

    [SerializeField] protected JunkRandom junkRandom;
    public JunkRandom JunkRandom { get => junkRandom; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkRandom();
        this.LoadJunkDespawn();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
    }
    protected virtual void LoadJunkRandom()
    {
        if (this.junkRandom != null) return;
        this.junkRandom = GetComponent<JunkRandom>();
    }
    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = GetComponent<JunkDespawn>();
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.SpawnPoints != null) return;
        this.spawnPoints = Transform.FindObjectOfType<SpawnPoints>();//su dung ham findObjectOfType vi no la object ngoai 
    }
}
