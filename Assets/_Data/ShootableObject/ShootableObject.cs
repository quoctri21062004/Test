using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObjectSO", menuName = "ScriptableObject/ShootableObject")]
public class ShootableObject : ScriptableObject
{
    public string objName = "ShootableObject";
    public ObjectType objType = 0;
    public int hpMax = 2;
    public List<ItemDropRate> dropList;
}