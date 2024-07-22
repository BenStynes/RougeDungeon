using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    private bool holdingDirection = false;
    
    [Export] private Timer DashTimerNode;
    [Export(PropertyHint.Range,"0,20,0.1")] private float speed = 10;
        public override void _Ready()
    {
     base._Ready();
     DashTimerNode.Timeout += HandleDashTimeout;
    
    }
    public override void _PhysicsProcess(double delta)
    {
       characterNode.HandleGravity(delta);
        characterNode.Flip();
       characterNode.MoveAndSlide();
    }
    protected override void EnterState()
    {
        
       // characterNode.AnimPlayerNode.Play(GameConstants.ANIM_SLIDE);
          characterNode.Sprite3DNode.Animation = GameConstants.ANIM_SLIDE;

        characterNode.Velocity = new(characterNode.direction.X,0,characterNode.direction.Y);

        if (characterNode.Velocity == Vector3.Zero)
        {
           characterNode.Velocity = characterNode.Sprite3DNode.FlipH ? 
            Vector3.Left: 
            Vector3.Right;
        }
        characterNode.Velocity *=  speed;
        DashTimerNode.Start();
        SetPhysicsProcess(true);
        SetProcessInput(true);
        
    }

    private void HandleDashTimeout()
    {
     
        
     if(holdingDirection == true)
       {
      characterNode.StateMachineNode.SwitchState<PlayerMoveState>();
         characterNode.Velocity = characterNode.Velocity = new(characterNode.direction.X,0,characterNode.direction.Y);
        characterNode.Velocity *=  speed/2;
       }
     else
       {
      characterNode.StateMachineNode.SwitchState<PlayerIdleState>();
          characterNode.Velocity = Vector3.Zero;
       }
    }
     public override void _Input(InputEvent @event)
    {
      if (Input.IsActionPressed(GameConstants.INPUT_MOVE_LEFT) || 
      Input.IsActionPressed(GameConstants.INPUT_MOVE_RIGHT)
       ||
    Input.IsActionPressed(GameConstants.INPUT_MOVE_FORW) || 
    Input.IsActionPressed(GameConstants.INPUT_MOVE_BACK))
      {
          
          holdingDirection = true;
        
      }
      else{
        return;
      }
    }
}
