using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointAt : MonoBehaviour
{

    [SerializeField]
    Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   if (target)
        {
            float angle = angleFinder(transform.position, target.position);
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        }else
        {
            float angle = angleFinder(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);
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
