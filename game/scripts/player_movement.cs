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

    private AnimatedSprite _anim;

    private Direction direction = Direction.left;

    public delegate void Death();

    public override void _Ready()
    {
        _anim = GetNode<AnimatedSprite>("AnimatedSprite");

        GameManager.player_Movement = this;
    }

    public override void _Process(float delta)
    {
        float moveAmount = speed * delta;
        Vector2 moveVector = new Vector2(0, 0);
        if (health > 0)
        {
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
                _anim.Play("run_left");
                direction = Direction.left;
            }

            if (Input.IsActionPressed("right"))
            {
                moveVector.x += moveAmount;
                _anim.Play("run_right");
                direction = Direction.right;
            }


            if (!Input.IsActionPressed("left") && !Input.IsActionPressed("right"))
            {
                if (direction != Direction.left)
                {
                    _anim.Play("idl_right");
                }
                else
                {
                    _anim.Play("idl_left");
                }
            }
            Position += moveVector;
            MoveAndCollide(moveVector);
        }


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
        if (obj.Owner is PickUp)
        {
            if (obj.Owner is MagicPotion)
            {
                MagicPotion potion = obj.Owner as MagicPotion;
                potion.Use();
            }
        }
    }

    public void TakeDamage()
    {
        GD.Print("Player has taken damage");
        health -= 5;
        GD.Print("Current health " + health);
        _anim.Play("take_damage");
        if (health <= 0)
        {
            health = 0;
            GD.Print("Player has died!");
            _anim.Play("die");
        }
    }

    private void _on_AnimatedSprite_animation_finished()
    {
        if (_anim.Animation == "die")
        {
            _anim.Stop();
            Hide();
            GD.Print("Anim finished");
            EmitSignal(nameof(Death));
        }
    }

    public void RespawnPlayer()
    {
        Show();
        health = 10;
    }
}
