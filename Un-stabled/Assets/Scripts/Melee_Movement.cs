using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Movement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 10f;
    private CharacterController2D controller;
    private float horizontalMove = 0f;
    private bool jump;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float targetRange;

    [SerializeField]
    private Transform weapon;
    [SerializeField]
    private int angle = 45;

    public bool beegSmack = false;

    [SerializeField]
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = distanceCalc(transform.position, target.position);
        float angleToTarget = angleFinder(transform.position, target.position);


        if(angleToTarget > 10)
        {
            //Debug.Log("JUMP");
            jump = true;
        }
        else
        {
            //Debug.Log("NO JUMP");
            jump = false;
        }

        if (dist > targetRange)
        {
            // Far Range
            float targetDirection = transform.position.x - target.position.x;
            targetDirection = targetDirection > 0 ? -1 : 1;
            horizontalMove = targetDirection * runSpeed;
            
        }
        else if (dist < 2.5)
        {
            if (counter > 60)
            {
                // Close Range
                if (beegSmack)
                {
                    //Debug.Log("UNWHACK");
                    weapon.rotation *= Quaternion.Euler(0, 0, (angle*-1));
                    beegSmack = false;
                }
                else
                {
                    weapon.rotation *= Quaternion.Euler(0, 0, angle);
                    //Debug.Log("WHACK");
                    beegSmack = true;
                }
                counter = 0;
            }
        }
        else
        {
            // Middle Range
            //horizontalMove = 0;
        }
        counter++;
    }

    // FixedUpdate is called once per tick
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    }


    private float distanceCalc(Vector2 A, Vector2 B)
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
