using Godot;
using System;

public class main : Node2D
{
    [Export]
    public Position2D RespawnPoint;

    public override void _Ready()
    {

    }

    public void RespawnPlayer()
    {
         GetNode<player_movement>("player");

    }
}
