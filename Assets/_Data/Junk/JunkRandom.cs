using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : TrisMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl=GetComponent<JunkCtrl>();
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        Transform randPos = this.junkCtrl.SpawnPoints.GetRandom();
        Vector3 pos = randPos.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), 2f);

    }
}
