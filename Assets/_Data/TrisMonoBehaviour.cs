using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrisMonoBehaviour : MonoBehaviour
{

    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Start()
    {
        //
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void LoadComponents()
    {
        //for override
    }
    protected virtual void ResetValue()
    {
        //
    }
    protected virtual void OnEnable()
    {
        //
    }
}
