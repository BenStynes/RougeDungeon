using Godot;
using System;

public partial class PlayerDeathState : PlayerState
{

       protected override void EnterState()
    {
        characterNode.Sprite3DNode.Animation = GameConstants.ANIM_DEAD;
          characterNode.Sprite3DNode.Play();
         

        characterNode.Sprite3DNode.AnimationFinished += HandleAnimationFinished;


    }

    private void HandleAnimationFinished()
    {
      characterNode.QueueFree();
    }
}
