using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoints : TrisMonoBehaviour
{
    [SerializeField] protected List <Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform point in transform) // duyet qua tat ca
                                               // cac transform cua cac con cua object hien tai
        {
            this.points.Add(point);
        }
    }
    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }
}
