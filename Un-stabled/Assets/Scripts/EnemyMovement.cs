using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float runSpeed = 10f;
    private CharacterController2D controller;
    private float horizontalMove = 0f;
    private bool jump;
    Animator animator;

    public Transform target;
    [SerializeField]
    private float targetRange;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = distanceCalc(transform.position, target.position);
        //Debug.Log(dist.ToString());
        float angleToTarget = angleFinder(transform.position, target.position);
        if (angleToTarget > 10)
        {
            //Debug.Log("JUMP");
            jump = true;
        }
        else
        {
            //Debug.Log("NO JUMP");
            jump = false;
        }
        //Debug.Log(dist.ToString());

        if (dist > targetRange)
        {
            // Far Range
            float targetDirection = transform.position.x - target.position.x;
            targetDirection = targetDirection > 0 ? -1 : 1;
            horizontalMove = targetDirection * runSpeed;
            jump = Random.Range(0f, 1f) > .95f;
        }
        else if (dist < (targetRange / 2))
        {
            /*
            // Close Range
            float targetDirection = transform.position.x - target.position.x;
            targetDirection = targetDirection > 0 ? -1 : 1;
            horizontalMove = targetDirection * runSpeed;
            jump = Random.Range(0f, 1f) > .95f;
            horizontalMove = horizontalMove * -1;
            */
            
        }
        else
        {
            // Middle Range
            horizontalMove = 0;
        }
    }

    // FixedUpdate is called once per tick
    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        try
        {
            animator.SetBool("walking", Mathf.Abs(horizontalMove) > 0.01f);
        }catch{
            
        }
    }


    float distanceCalc(Vector2 A, Vector2 B)
    {
        return Vector3.Distance(A, B);
    }

    private float angleFinder(Vector3 entity, Vector3 aim)
    {
        float deltaX = aim.x - entity.x;
        float deltaY = aim.y - entity.y;
        float radians = Mathf.Atan2(deltaY, deltaX);
        float degrees = radians * Mathf.Rad2Deg;
        return degrees;
    }
}
