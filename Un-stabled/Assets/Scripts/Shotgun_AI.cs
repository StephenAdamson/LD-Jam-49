using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun_AI : MonoBehaviour
{
    Vector3 entityLocation; // This the "gun owner" position. e.g. The character holding the gun object
    Vector3 aimLocation;    // This is the aim location. 
    [SerializeField]
    Rigidbody2D bulletObject;
    [SerializeField] private Collider2D target;
    // Bullet force
    public int bulletStronk = 1000;
    [SerializeField]
    Transform bulletFirePoint;

    [SerializeField]
    Transform gunPrefab;

    [SerializeField]
    int frameCounter = 60;

    [SerializeField]
    int pellets = 10;

    int initFrameCounterValue = 0;

    CharacterController2D owner;

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.GetComponent<CharacterController2D>();
        initFrameCounterValue = frameCounter;
    }

    // Update is called once per frame
    void Update()
    {
        entityLocation = transform.position;
        aimLocation = target.transform.position;

        float angle = angleFinder(entityLocation, aimLocation);
        //Debug.Log(angle.ToString());
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

        if (frameCounter == 0)
        {
            for (int i = 0; i < pellets; i++)
            {
                float spray = Random.Range(-45.0f, 45.0f);
                Rigidbody2D bullet = Instantiate(bulletObject);
                //Black magic
                Vector3 direction = (Vector2)(Quaternion.Euler(0, 0, angle+spray) * Vector2.right);
                //EOBlack magic
                bullet.AddForce(direction * bulletStronk);
                bullet.transform.position = bulletFirePoint.position;
                bullet.transform.rotation = Quaternion.Euler(0, 0, angle+spray);
                frameCounter = initFrameCounterValue;
            }
        }
        frameCounter--;
        Debug.Log(frameCounter);
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
