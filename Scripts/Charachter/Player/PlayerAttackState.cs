using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{

    [Export]private Timer comboTimerNode;
    private int comboCounter = 1;
    private int maxComboCount = 2;

    public override void _Ready()
    {
        base._Ready();
        
        comboTimerNode.Timeout += () => comboCounter = 1;
    }
    protected override void EnterState()
    {
        characterNode.Sprite3DNode.Animation = GameConstants.ANIM_ATTACK +comboCounter;
          characterNode.Sprite3DNode.Play(  characterNode.Sprite3DNode.Animation,1.5f);
          characterNode.AnimPlayerNode.Play(GameConstants.ANIM_ATTACK +comboCounter,-1,1.5f);

           characterNode.Sprite3DNode.AnimationFinished += HandleAnimationFinished;
    }
     public override void _Input(InputEvent @event)
    {
        base._Input(@event);
    }
 protected override void ExitState()
    {
           characterNode.Sprite3DNode.AnimationFinished -= HandleAnimationFinished;
           comboTimerNode.Start();
        
    }
    private void HandleAnimationFinished()
    {
     
     comboCounter++;
     comboCounter = Mathf.Wrap(comboCounter,1 ,maxComboCount +1);

        characterNode.ToggleHitbox(true);


     characterNode.StateMachineNode.SwitchState<PlayerIdleState>();

    }
    private void PerformHit()
    {
        Vector3 newPos = characterNode.Sprite3DNode.FlipH ? 
        Vector3.Left :  
        Vector3.Right;
        float distanceMultiplier = 0.75f;
        newPos *= distanceMultiplier;


        characterNode.HitboxAreaNode.Position = newPos;

        characterNode.ToggleHitbox(false);
    }

}
