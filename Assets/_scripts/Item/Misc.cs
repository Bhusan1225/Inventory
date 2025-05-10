using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Misc")]
public class Misc : Item
{

    //[Header("Misc")]


    public override Item GetItem() { return this; }
    public override Tool GetTool() { return null; }
    public override Misc GetMisc() { return this; }
    public override Consumeable GetConsumeable() { return null; }
}
