using Godot;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public partial class EnemyChaseState : EnemyState
{
     [Export(PropertyHint.Range, "0,20,0.1")]private Timer chaseTimerNode;    
  
    protected override void EnterState()
    {
        characterNode.Sprite3DNode.Animation = GameConstants.ANIM_MOVE;
        characterNode.Sprite3DNode.Play();
        target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        chaseTimerNode.Timeout += HandleTimeout;
        characterNode.AttackAreaNode.BodyEntered += HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExited;
    }

   


    protected override void ExitState()
    {
        chaseTimerNode.Timeout -= HandleTimeout;
        characterNode.AttackAreaNode.BodyEntered -= HandleAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExited;

    }
    public override void _PhysicsProcess(double delta)
    {
        
        if (!characterNode.IsOnFloor())
        {
            characterNode.HandleGravity(delta);
        }
   

        Move();
    }

     private void HandleTimeout()
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
    }
 private void HandleChaseAreaBodyExited(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
      
    }
}
