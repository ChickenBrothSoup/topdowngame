using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : Movement
{
    public float _movementSpeed = 2f;
    public float RotationDEgree = 22.5f;
    protected Transform target;
    protected Vector2 _moveDirection;

   
    

    

    protected override void Start()
    {
        base.Start();

        target = GameObject.FindWithTag("Player").transform;
    }

    protected override void HandleInput()
    {
        if (target == null) 
            return;


        _InputDirection = new Vector3 (target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);

        Debug.DrawRay(transform.position, _InputDirection,Color.yellow);

        
    }


    protected override void HandleRotation()
    {
        base.HandleRotation();  
    }






}
