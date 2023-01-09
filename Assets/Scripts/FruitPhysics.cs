using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FruitPhysics : MonoBehaviour
{
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetImpulse(float force, Direction direction)
    {
        Vector2 dir = direction switch
        {
            Direction.Left => Vector2.left,
            Direction.Right => Vector2.right,
            Direction.Up => Vector2.up,
            Direction.Down => Vector2.down,
            _ => throw new System.NotImplementedException()
        };
        rb.AddForce(force * dir, ForceMode2D.Impulse);
    }
    
}

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}