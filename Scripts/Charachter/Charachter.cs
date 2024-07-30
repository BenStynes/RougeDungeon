using Godot;
using System;

public partial class Charachter : CharacterBody3D
{
  [ExportGroup("Required Nodes")]
  [Export] public AnimationPlayer AnimPlayerNode {get; private set;}
  [Export] public AnimatedSprite3D Sprite3DNode {get; private set;}
 [Export]public StateMachine StateMachineNode {get; private set;}

  [ExportGroup("AI Nodes")]
 [Export]public Path3D PathNode {get; private set;}
 [Export] public NavigationAgent3D AgentNode{get; private set;}
 [Export] public Area3D ChaseAreaNode {get; private set;}

   [ExportGroup("Attack Nodes")]
   [Export] public Area3D AttackAreaNode {get; private set;}
    public Vector2 direction = new();

     public float Gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public void HandleGravity(double delta)
    {
        Vector3 velocity = Velocity;
        if (!IsOnFloor())
        {
            velocity.Y -= Gravity * (float)delta;
            Velocity = velocity;
            MoveAndSlide();
        }
    }
   
    
    
    
    public void Flip()
    { bool isnotMovingHorizontal = Velocity.X == 0; 
      bool isMovingLeft = Velocity.X < 0;
      if(isnotMovingHorizontal == false)
      {
        Sprite3DNode.FlipH =isMovingLeft;
      }
    }
}
