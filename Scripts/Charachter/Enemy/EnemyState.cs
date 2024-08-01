using System;
using Godot;

public abstract partial class EnemyState : CharachterState
{
    protected Vector3 destination;

    public override void _Ready()
    {
        base._Ready();
            characterNode.GetStatResource(Stat.Health).OnZero += handleZeroHealth;
    }

    private void handleZeroHealth()
    {
               characterNode.StateMachineNode.SwitchState<EnemyDeathState>();

    }

    protected CharacterBody3D target;

    protected Vector3 GetPointGlobalPosition(int index)
    {
         Vector3 localPos = characterNode.PathNode.Curve.GetPointPosition(index);
        Vector3 globalPos =  characterNode.PathNode.GlobalPosition;
        return  localPos + globalPos;
    }

    protected void Move()
    {
        characterNode.AgentNode.GetNextPathPosition();
        characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);
        characterNode.Flip();
        characterNode.MoveAndSlide();

    }
    protected void HandleChaseAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyChaseState>();
    }

    
    protected void HandleAttackAreaBodyEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }
}