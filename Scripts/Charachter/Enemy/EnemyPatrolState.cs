using Godot;
using System;

public partial class EnemyPatrolState : EnemyState
{
    [Export] private Timer idleTimerNode;
    [Export(PropertyHint.Range, "0,20,0.1")]
    private float maxIdleTime = 4;
    private int pointIndex = 0;
     protected override void EnterState()
    {
       
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_MOVE;
          characterNode.Sprite3DNode.Play();

        pointIndex = 1;

        destination = GetPointGlobalPosition(pointIndex);
        characterNode.AgentNode.TargetPosition = destination;
       
       characterNode.AgentNode.NavigationFinished += HandleNavigationFinished;
        idleTimerNode.Timeout += HandleTimeout;
    }

    protected override void ExitState()
    {
       characterNode.AgentNode.NavigationFinished -= HandleNavigationFinished;
        idleTimerNode.Timeout -= HandleTimeout;
    }


    public override void _PhysicsProcess(double delta)
    {
        if (!characterNode.IsOnFloor())
        {
            characterNode.HandleGravity(delta);
        }
        if(!idleTimerNode.IsStopped())
        {
            GD.Print("MOVE STOPPED");
           return;
          
        }
          Move();
    }
    
    private void HandleNavigationFinished()
    {
       characterNode.Sprite3DNode.Animation = GameConstants.ANIM_IDLE;
       characterNode.Sprite3DNode.Play();
       
       RandomNumberGenerator rng = new();
       idleTimerNode.WaitTime = rng.RandfRange(0, maxIdleTime);

       idleTimerNode.Start();

        
       
    }

    private void HandleTimeout()
    {
       characterNode.Sprite3DNode.Animation = GameConstants.ANIM_MOVE;
       characterNode.Sprite3DNode.Play();


       pointIndex = Mathf.Wrap(
       pointIndex + 1,0,characterNode.PathNode.Curve.PointCount);
       destination = GetPointGlobalPosition(pointIndex);
       characterNode.AgentNode.TargetPosition = destination;


    }

}
