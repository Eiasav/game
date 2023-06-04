using Godot;
using System;

public class GameManager : Node2D
{
    [Export]
    public Position2D RespawnPoint;

    public static GameManager Instance;

    public static player_movement player_Movement;
    public override void _Ready()
    {
        if (Instance == null)
            Instance = this;
        else
            QueueFree();
    }

    public void RespawnPlayer()
    {
        player_movement pm = GetNode<player_movement>("player");
        pm.GlobalPosition = RespawnPoint.GlobalPosition;
        pm.RespawnPlayer();
    }

    private void _on_player_Death()
    {
        RespawnPlayer();
    }
}
