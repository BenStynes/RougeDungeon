using Godot;
using System;

public partial class Player : Charachter
{
  
    public override void _Input(InputEvent @event)
    {
    
    direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT,GameConstants.INPUT_MOVE_RIGHT,
    GameConstants.INPUT_MOVE_FORW,GameConstants.INPUT_MOVE_BACK);

    
    }
    
    
    
  
}
