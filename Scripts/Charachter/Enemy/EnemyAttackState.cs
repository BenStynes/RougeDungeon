using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState
{
private Vector3 targetPosition;
    protected  override void EnterState()
    {
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_ATTACK;
          characterNode.Sprite3DNode.Play();
          characterNode.AnimPlayerNode.Play(GameConstants.ANIM_ATTACK);

        
         Node3D target = characterNode.AttackAreaNode.GetOverlappingBodies().First();

        characterNode.Sprite3DNode.AnimationFinished += HandleAnimationFinished;
         targetPosition = target.GlobalPosition;
          
    }

    private void HandleAnimationFinished()
    {
        characterNode.ToggleHitbox(true);

         Node3D target = characterNode.AttackAreaNode.GetOverlappingBodies().FirstOrDefault();
                
          if(target == null)
          {
         Node3D chaseTarget = characterNode.ChaseAreaNode.GetOverlappingBodies().FirstOrDefault();
            if(chaseTarget ==null)
            {
            characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
            return;
            }
            characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
            return;
          }
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_ATTACK;
          characterNode.Sprite3DNode.Play();
          characterNode.AnimPlayerNode.Play(GameConstants.ANIM_ATTACK);


          targetPosition = target.GlobalPosition;

         Vector3 direction = characterNode.GlobalPosition.DirectionTo(targetPosition);
         characterNode.Sprite3DNode.FlipH = direction.X < 0;
    }

    protected  override void ExitState()
    {
      
        characterNode.Sprite3DNode.AnimationFinished -= HandleAnimationFinished;
        
    }

  public override void _PhysicsProcess(double delta)
    {
     
    
       
         characterNode.HandleGravity(delta);
    }
  private void PerformHit()
  {
        characterNode.ToggleHitbox(false);
        characterNode.HitboxAreaNode.GlobalPosition = targetPosition;
  }
}
