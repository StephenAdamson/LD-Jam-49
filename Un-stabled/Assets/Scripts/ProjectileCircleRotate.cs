using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCircleRotate : MonoBehaviour
{
    Vector3 aimLocation;    // This is the aim location. 
    [SerializeField]
    Rigidbody2D projectile;
    // Bullet force
    public int bulletStronk = 1000;

    [SerializeField]
    int bulletCount = 1;

    [SerializeField]
    float spread = 3f;

    CharacterController2D owner;

    // Start is called before the first frame update
    void Start()
    {
        getOwner();
    }

    void getOwner()
    {
        try
        {
            owner = transform.parent.parent.parent.parent.GetComponent<CharacterController2D>();
        }
        catch
        {
            try
            {
                owner = transform.parent.parent.parent.GetComponent<CharacterController2D>();
            }
            catch
            {
                try
                {
                    owner = transform.parent.parent.GetComponent<CharacterController2D>();
                }
                catch
                {
                    Debug.Log("Weapon likely attached to invalid shooter");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!owner){
            getOwner();
            Debug.Log("Fail");
            return;
        }
        float angle = angleFinder(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (owner.m_FacingRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, -1, 1);
        }

        //shoot gun

        if (Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < bulletCount; i++)
            {
                Rigidbody2D bullet = Instantiate(projectile);
                bullet.transform.position = transform.position;
                bullet.AddForce(GameManager.ProjMath.trajectoryVectorToHitTarget(transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition)+(Vector3.up * Random.Range(-spread,spread)), bulletStronk));
                bullet.gameObject.GetComponent<ProjectileBehavior>().setOwner(this.gameObject);
                bullet.gameObject.GetComponent<ProjectileBehavior>().isPlayer = true;
            }
        }
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
