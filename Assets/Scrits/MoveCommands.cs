using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommands :Commands
{   
    //Concerete class 
    Transform target;
    Vector2 translation;
    Vector3 scale;
    Vector3 inverseScale;
    public MoveCommands(Transform target, Vector2 translation, Vector3 scale)
    {
        this.target = target;
        this.translation = translation;
        this.scale = scale;
        inverseScale = new Vector3( scale.x, scale.y, scale.z);
    }

    public override void Exceute()
    {
        target.Translate(translation);
        target.localScale = scale;
        CommandManager.instance.PushCommand(this);
    }


    public override void undo()
    {
        target.Translate(-translation);
        target.localScale = inverseScale;
    }

  

    public override void redo()
    {
        target.Translate(translation);
        target.localScale = scale;
        CommandManager.instance.PushCommand(this);
    }
}
