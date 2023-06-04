using Godot;
using System;

public class MagicPotion : PickUp
{
    public float MagicAmount = 20f;

    public override void _Ready()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("Bounce");
    }

    public void Use()
    {
        GameManager.player_Movement.UpdateMana(MagicAmount);
        QueueFree();
    }
}
