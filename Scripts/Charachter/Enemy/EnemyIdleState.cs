using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{

    
       public override void _PhysicsProcess(double delta)
    {
     
    
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();

       
         characterNode.HandleGravity(delta);
    }
     protected override void EnterState()
    {
       
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_IDLE;
         characterNode.Sprite3DNode.Play();
    }
}
