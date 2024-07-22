using Godot;
using System;

public partial class Enemy : Charachter
{
  [ExportGroup("Required Nodes")]
  [Export] public AnimatedSprite3D Smoke {get; private set;}
}
