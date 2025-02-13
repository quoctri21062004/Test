using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppearing : TrisMonoBehaviour
{

    [SerializeField] protected bool appeared = false;
    public bool Appeared => appeared;

    [SerializeField] protected List<InterfaceObjAppearObserver> observers = new List<InterfaceObjAppearObserver>();

    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
    }
    protected virtual void OnDisable()
    {
        this.appeared = false;
        this.OnAppearStart();
    }
    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }
    protected abstract void Appearing();
    public virtual void Appear()
    {
        this.appeared = true;  
        this.OnAppearFinish();
    }
    public virtual void ObserverAdd(InterfaceObjAppearObserver observer)
    {
        this.observers.Add(observer);
    }
    protected virtual void OnAppearStart()
    {
        foreach (InterfaceObjAppearObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }
    }
    protected virtual void OnAppearFinish()
    {
        foreach (InterfaceObjAppearObserver observer in this.observers)
        {
            observer.OnAppearFinish();
        }
    }
}
