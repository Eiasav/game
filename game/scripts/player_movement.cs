using Godot;
using System;

public class player_movement : KinematicBody2D
{
    private enum Direction
    {
        left,
        right
    }; 
    private AnimatedSprite _animRun_right;
    private AnimatedSprite _animIdl_right;
    private AnimatedSprite _animIdl_left;
    private AnimatedSprite _animRun_left;

    public override void _Ready()
    {
        _animIdl_right = GetNode<AnimatedSprite>("AnimatedSprite");
        _animRun_right = GetNode<AnimatedSprite>("AnimatedSprite");
        _animIdl_left = GetNode<AnimatedSprite>("AnimatedSprite");
        _animRun_left = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    public override void _Process(float delta)
    {
        Direction direction_left = Direction.left;
        Direction direction_right = Direction.right;
        float speed = 150;
        float moveAmount = speed * delta;
        Vector2 moveVector = new Vector2(0, 0);
        if (Input.IsActionPressed("up"))
        {
            moveVector.y -= moveAmount;
        }
        if (Input.IsActionPressed("down"))
        {
            moveVector.y += moveAmount;
        }

        if (Input.IsActionPressed("left"))
        {
            moveVector.x -= moveAmount;
            _animRun_left.Play("run_left");
        }

        if (Input.IsActionPressed("right"))
        {
            moveVector.x += moveAmount;
            _animRun_right.Play("run_right");
        }

        if (!Input.IsActionPressed("left") && !Input.IsActionPressed("right"))
        {
            if (direction_left == Direction.left) _animIdl_left.Play("idl_left");
            if (direction_right == Direction.right) _animIdl_right.Play("idl_right");
        }

        Position += moveVector;
    }
}
