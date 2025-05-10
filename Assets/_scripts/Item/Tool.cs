using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Tool Class", menuName ="Item/Tool")]
public class Tool :Item
{
    [Header("Tool")]
    public ToolType toolType;
    public enum ToolType
    {
        weapon,
        pickaxe,
        hammer,

    }

    public override Item GetItem() { return this; }
    public override Tool GetTool() { return this; }
    public override Misc GetMisc() { return null; }
    public override Consumeable GetConsumeable() { return null; }

}
