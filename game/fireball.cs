using Godot;
using System;

public class fireball : AnimatedSprite
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SpriteFrames spriteFrames = this.Frames;
        foreach (string name in spriteFrames.GetAnimationNames())
        {
            for (int i = 0; i < spriteFrames.GetFrameCount(name); i++)
            {
                //AtlasTexture atlasTexture1 = (AtlasTexture)spriteFrames.GetFrame(name, i);
                //StreamTexture streamTexture = spriteFrames as StreamTexture;
            }
        }
    }

    public override void _Process(float delta)
    {
      
    }
}
