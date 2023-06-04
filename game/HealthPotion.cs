using Godot;
using System;

public class HealthPotion : PickUp
{
    public override void _Ready()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("Bounce2");
    }

    public void Use()
    {

    }
}
