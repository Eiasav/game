using Godot;
using System;

public class MagicPotion : PickUp
{
    public override void _Ready()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("Bounce");
    }

    public void Use()
    {

    }
}
