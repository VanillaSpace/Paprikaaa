using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChoppable : ToolHit
{
    public override void Hit()
    {
        Destroy(gameObject);
    }
}
