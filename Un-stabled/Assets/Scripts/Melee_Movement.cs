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
    private meleeItemCotroller weapon;
    [SerializeField]
    private int angle = 45;

    public bool beegSmack = false;

    public float cooldown = 1f;
    private float cooldownCounter = 0f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        if(weapon){
            weapon.setOwner(gameObject);
        }
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownCounter += Time.deltaTime;
        float dist = distanceCalc(transform.position, target.position);
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

        if (dist > targetRange)
        {
            // Far Range
            float targetDirection = transform.position.x - target.position.x;
            targetDirection = targetDirection > 0 ? -1 : 1;
            horizontalMove = targetDirection * runSpeed;

        }
        else if (dist < 2.5)
        {
            // Close Range
            if (beegSmack)
            {
                beegSmack = false;
            }
            else
            {
                if (weapon)
                {
                    weapon.whack();
                }
                else
                {
                    if(cooldownCounter > cooldown)
                        
                            for (float o = -1f; o <= 1f; o += 1f)
                            {
                                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + (transform.right / 2 * (controller.m_FacingRight ? 1 : -1)) + new Vector3(0, (0.333f) * o, 0), .5f);
                                for (int i = 0; i < colliders.Length; i++)
                                {
                                    if (colliders[i].gameObject != gameObject)
                                    {
                                        try
                                        {
                                            HealthController eh = colliders[i].gameObject.GetComponent<HealthController>();
                                            if (eh)
                                            {
                                                Vector2 dir = (eh.gameObject.transform.position + (Vector3.up / 4)) - (transform.position - (Vector3.up / 4));
                                                dir = dir.normalized * 500;
                                                eh.takeDamage(.5f, dir);
                                                anim.SetTrigger("attack");
                                                cooldownCounter = 0;
                                                goto outlookreturnthing;
                                            }
                                        }
                                        catch
                                        {

                                        }
                                    }
                                }
                            }
                    outlookreturnthing:
                    Debug.Log("");
                }
                beegSmack = true;
            }
        }
        else
        {
            // Middle Range
            //horizontalMove = 0;
        }
    }

    // FixedUpdate is called once per tick
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        try
        {
            anim.SetBool("walking", Mathf.Abs(horizontalMove) > 0.01f);
        }catch{
            
        }
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
