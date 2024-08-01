using Godot;
using System;

public partial class EnemyDeathState : EnemyState
{

    protected override void EnterState()
    {
        characterNode.Sprite3DNode.Animation = GameConstants.ANIM_DEAD;
          characterNode.Sprite3DNode.Play();
          characterNode.AnimPlayerNode.Play(GameConstants.ANIM_DEAD);

        characterNode.Sprite3DNode.AnimationFinished += HandleAnimationFinished;


    }

    private void HandleAnimationFinished()
    {
      characterNode.QueueFree();
    }

}
