using Godot;
using System;

public class FireBall : Spell
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }

    public override void SetUp()
    {

    }

    public override void CastSpell()
    {
        throw new NotImplementedException();
    }

    public override void LoadResourcePath()
    {
        throw new NotImplementedException();
    }

    public void _on_Area2D_body_enterned(object body)
    {

    }
}
