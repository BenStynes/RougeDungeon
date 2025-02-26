using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
 
       public override void _PhysicsProcess(double delta)
    {
       if(characterNode.direction != Vector2.Zero)
       {
      characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
       }
         characterNode.HandleGravity(delta);
    }
 public override void _Input(InputEvent @event)
    {
        base._Input(@event);
    }
    
    protected override void EnterState()
    {
          
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_IDLE;
          characterNode.Sprite3DNode.Play();
    }
}
