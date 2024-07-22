using Godot;
using System;

public abstract partial class CharachterState : Node
 {
protected Charachter characterNode;
 public override void _Ready()
    {
    characterNode = GetOwner<Charachter>();
     SetPhysicsProcess(false);
      SetProcessInput(false);
    }
    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == GameConstants.NOTIFICATION_EXIT)
        {
         
           SetPhysicsProcess(false);
           SetProcessInput(false);

           ExitState();
        }
        if(what == GameConstants.NOTIFICATION_ENTER)
        {
        EnterState();
        SetPhysicsProcess(true);
        SetProcessInput(true);
        }
    }

protected virtual void EnterState()
{

        characterNode.Sprite3DNode.Play();

}
protected virtual void ExitState(){

}

}