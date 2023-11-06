using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{ 
    //Client
    public GameObject target;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                string objectName = hit.collider.gameObject.name;

                switch (objectName)
                {
                    case "Up":
                        MoveCommands moveup = new MoveCommands(transform, Vector2.up, transform.localScale);
                        moveup.Exceute();
                        break;

                    case "Down":
                        MoveCommands movedown = new MoveCommands(transform, Vector2.down, transform.localScale);
                        movedown.Exceute();
                        break;

                    case "Left":
                        MoveCommands moveleft = new MoveCommands(transform, Vector2.left, transform.localScale);
                        moveleft.Exceute();
                        break;

                    case "Right":
                        MoveCommands moveRight = new MoveCommands(transform, Vector2.right, transform.localScale);
                        moveRight.Exceute();
                        break;

                    case "Undo":
                        CommandManager.instance.UndoLastCommand();
                        break;

                    case "Increase":
                        Debug.Log(objectName);
                        target.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                        MoveCommands scale = new MoveCommands(transform, Vector2.zero, transform.localScale);
                        scale.Exceute();
                        break;

                    case "Decrease":
                        target.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                        break;

                    case "Redo":
                        CommandManager.instance.RedoLastCommand();
                        break;

                    default:
                        // Default case if objectName doesn't match any of the cases above.
                        break;
                }
            }
        }
    }
}
