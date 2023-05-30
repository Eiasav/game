using Godot;
using System;

public class player_movement : KinematicBody2D
{ 
    private float mana = 100f;
    private float maxMana = 100f;
    private float manaTimerReset = 2f;
    private float manaTimer = 2f;
    private float speed = 150;
    public int health = 100;

    private enum Direction
    {
        left,
        right
    }; 

    private AnimatedSprite _animRun_right;
    private AnimatedSprite _animIdl_right;
    private AnimatedSprite _animIdl_left;
    private AnimatedSprite _animRun_left;
    private AnimatedSprite _anim_TakeDamage;
    private AnimatedSprite _anim_Die;

    private Direction direction = Direction.left;

    public override void _Ready()
    {
        _animIdl_right = GetNode<AnimatedSprite>("AnimatedSprite");
        _animRun_right = GetNode<AnimatedSprite>("AnimatedSprite");
        _animIdl_left = GetNode<AnimatedSprite>("AnimatedSprite");
        _animRun_left = GetNode<AnimatedSprite>("AnimatedSprite");
        _anim_TakeDamage = GetNode<AnimatedSprite>("AnimatedSprite");
        _anim_Die = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    public override void _Process(float delta)
    {
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
            direction = Direction.left;
        }

        if (Input.IsActionPressed("right"))
        {
            moveVector.x += moveAmount;
            _animRun_right.Play("run_right");
            direction = Direction.right;
        }

        if (!Input.IsActionPressed("left") && !Input.IsActionPressed("right"))
        {
            if (direction != Direction.left)
            {
                _animIdl_left.Play("idl_right");
            }
            else
            {
                _animIdl_right.Play("idl_left");
            }
        }

        Position += moveVector;

        if (mana < 100 && manaTimer <= 0)
        {
            mana += delta * 1;
            GD.Print(mana);
        }
        else if (mana != 100)
        {
            manaTimer -= delta;
        }
    }

    public void UpdateMana (float manaAmount)
    {
        mana += manaAmount;
        if (mana >= maxMana)
        {
            mana = maxMana;
        }
        else if (mana <= 0)
        {
            mana = 0;
        }
    }

    private void InterWithItems(Node obj)
    {
        if (obj is PickUp)
        {
            if (obj is MagicPotion)
            {
                MagicPotion potion = obj as MagicPotion;
                
            }
        }
    }

    public void TakeDamage()
    {
        GD.Print("Player has taken damage");
        health -= 5;
        GD.Print("Current health " + health);
        _anim_TakeDamage.Play("take_damage");
        if (health <= 0)
        {
            health = 0;
            GD.Print("Player has died!");
            _anim_Die.Play("die");
        }
    }
}
