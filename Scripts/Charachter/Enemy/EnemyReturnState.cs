using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
   
    public override void _Ready()
    {
        base._Ready();
       destination = GetPointGlobalPosition(0);
    }
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.AgentNode.IsNavigationFinished())
        {
        characterNode.StateMachineNode.SwitchState<EnemyPatrolState>();
         return;
        }
        if (!characterNode.IsOnFloor())
        {
            characterNode.HandleGravity(delta);
        }
     Move();
        

    }
    protected override void EnterState()
    {
       
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_MOVE;
          characterNode.Sprite3DNode.Play();
          characterNode.AgentNode.TargetPosition = destination;
          characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;

    }
     protected override void ExitState()
    {
                characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;

    }   
}
