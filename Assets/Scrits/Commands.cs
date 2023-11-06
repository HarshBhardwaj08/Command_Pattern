using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Commands 
{  //Abstract-Class
    public abstract void Exceute();
      
    public abstract void  undo();

    public abstract void redo();
}
