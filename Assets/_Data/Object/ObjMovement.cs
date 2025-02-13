using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : TrisMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected float minDistance = 1f;
    [SerializeField] protected float distance = 1f;
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, this.targetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
