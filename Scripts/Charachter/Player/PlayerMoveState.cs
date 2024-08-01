using Godot;
using System;
using System.Transactions;

public partial class PlayerMoveState : PlayerState
{ 
 [Export(PropertyHint.Range,"0,20,0.1")]private float baseSpeed = 5;
    
    public override void _PhysicsProcess(double delta)
    {
       if(characterNode.direction == Vector2.Zero)
       {
      characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
      return;
       }
   if (!characterNode.IsOnFloor())
        {
            characterNode.HandleGravity(delta);
        }
    else{
      characterNode.Velocity = new( characterNode.direction.X,0, characterNode.direction.Y);
       characterNode.Velocity*=baseSpeed;
       characterNode.Flip();
       characterNode.MoveAndSlide();
    }
    }


    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
    }


    protected override void EnterState()
    {
         
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_MOVE;
          characterNode.Sprite3DNode.Play();

    }
}
