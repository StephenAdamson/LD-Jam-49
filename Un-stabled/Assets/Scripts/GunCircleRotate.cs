using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCircleRotate : MonoBehaviour
{
    Vector3 aimLocation;    // This is the aim location. 
    [SerializeField]
    GameObject bulletObject;
    // Bullet force
    public int bulletStronk = 1000;
    [SerializeField]
    Transform bulletFirePoint;

    [SerializeField]
    int bulletCount = 1;

    [SerializeField]
    float spread = 3f;

    CharacterController2D owner;

    // Start is called before the first frame update
    void Start()
    {
        try{
            owner = transform.parent.parent.parent.GetComponent<CharacterController2D>();
        }catch{
            try{
                owner = transform.parent.parent.GetComponent<CharacterController2D>();
            }catch{
                Debug.Log("Weapon likely attached to invalid shooter");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
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
                GameObject bullet = Instantiate(bulletObject);
                bullet.GetComponent<ProjectileBehavior>().isPlayer = owner.gameObject.layer == 6;
                //Black magic
                Vector3 direction = (Vector2)(Quaternion.Euler(0, 0, (angle + Random.Range(-spread, spread))) * Vector2.right);
                //EOBlack magic
                bullet.transform.position = bulletFirePoint.position;
                bullet.GetComponent<Rigidbody2D>().AddForce(direction * (bulletCount > 3 ? bulletStronk * Random.Range(.9f, 1.1f) : bulletStronk));
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
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
