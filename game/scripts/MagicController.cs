using Godot;
using System;
using System.Collections.Generic;

public class MagicController : Node
{
    public PackedScene EquippedSpell = ResourceLoader.Load("res://scripts/FireBall.tscn") as PackedScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void CastSpell()
    {
        Spell current = EquippedSpell.Instance() as Spell;
        current.SetUp();
    }
}
