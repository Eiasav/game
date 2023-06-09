using Godot;
using System;

public class smalldemon : KinematicBody2D
{
    Sprite sprite;
    RayCast2D rayCastLeft;
    RayCast2D rayCastRight;
    private Vector2 velocity;
    private int speed = 30;
    private AnimationPlayer player;

    public override void _Ready()
    {
        sprite = GetNode<Sprite>("Sprite");
        rayCastLeft = GetNode<RayCast2D>("leftRayCast");
        rayCastRight = GetNode<RayCast2D>("rightRayCast");
        player = GetNode<AnimationPlayer>("AnimationPlayer");
        velocity.x = speed;
    }

    public override void _PhysicsProcess(float delta)
    {
        if(rayCastRight.IsColliding())
        {
            velocity.x = -speed;
            sprite.FlipH = false;
        }
        else if (rayCastLeft.IsColliding())
        {
            velocity.x = speed;
            sprite.FlipH = true;
        }
        if (!player.IsPlaying())
        {
            player.Play("fly");
        }
        MoveAndSlide(velocity, Vector2.Up);
    }

    public void _on_Area2D_body_entered(object body)
    {
        if (body is player_movement)
        {
            player_movement player = body as player_movement;
            player.TakeDamage();
        }
    }
}
