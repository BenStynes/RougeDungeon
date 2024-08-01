using Godot;
using System;

public abstract partial class PlayerState : CharachterState
 {

      public override void _Ready()
    {
        base._Ready();
            characterNode.GetStatResource(Stat.Health).OnZero += handleZeroHealth;
    }

    private void handleZeroHealth()
    {
               characterNode.StateMachineNode.SwitchState<PlayerDeathState>();

    }
       public  override void _Input(InputEvent @event)
    {
      CheckForAttackInput();

      if (Input.IsActionJustPressed(GameConstants.INPUT_MOVE_SLIDE))
      {
      characterNode.StateMachineNode.SwitchState<PlayerDashState>();
        
      }
    }
    protected void CheckForAttackInput()
    {
      if(Input.IsActionJustPressed(GameConstants.INPUT_ATTACK))
      {
         characterNode.StateMachineNode.SwitchState<PlayerAttackState>();
      }
    }
 }