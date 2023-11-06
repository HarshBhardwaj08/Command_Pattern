using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{ 
    //Invoker
    public static CommandManager instance { get; private set; }
    private Stack<Commands> commands = new Stack<Commands>();
    private Stack<Commands> undoStack = new Stack<Commands>();
    private Stack<Commands> redoStack = new Stack<Commands>();

    private void Awake()
    {
        instance = this;
    }

    public void PushCommand(Commands command)
    {
        commands.Push(command);

        // Clear the redo stack when a new command is added
        redoStack.Clear();
    }

    public void UndoLastCommand()
    {      
        if(commands == null)
        {
            Debug.Log("nulll");
        }
        if (commands?.Count == 0)
        {
            return;
        }

        var lastCommand = commands.Pop();
        lastCommand.undo();

        // Move the undone command to the redo stack
        undoStack.Push(lastCommand);
    }

    public void RedoLastCommand()
    {
        if (undoStack.Count == 0)
        {
            return;
        }

        var lastUndoneCommand = undoStack.Pop();
        lastUndoneCommand.Exceute();

        // Move the redone command back to the undo stack
        commands.Push(lastUndoneCommand);

        // Add the redone command to the redo stack
        redoStack.Push(lastUndoneCommand);
    }

}
