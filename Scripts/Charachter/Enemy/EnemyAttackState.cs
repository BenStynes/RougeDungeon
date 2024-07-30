using Godot;
using System;

public partial class EnemyAttackState : EnemyState
{
    protected  override void EnterState()
    {
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_ATTACK;
          characterNode.Sprite3DNode.Play();
        
          
    }

     protected  override void ExitState()
    {
      
        
    }

  public override void _PhysicsProcess(double delta)
    {
     
    if(characterNode.Sprite3DNode.IsPlaying() == false )
    {
        
        characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
    }
       
         characterNode.HandleGravity(delta);
    }

}
