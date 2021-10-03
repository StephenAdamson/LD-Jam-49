using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRangedAttack : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D projectile;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<EnemyMovement>().target;
    }

    // Update is called once per frame
    void Update()
    {
        if (projectile)
        {
            if (Random.Range(0f, 1f) > 0.99f)
            {
                Transform targetAim = target;
                targetAim.position += (Vector3.up/4f);
                Rigidbody2D weaponProjectile = Instantiate(projectile);
                weaponProjectile.transform.position = transform.position - ((transform.position - target.position).normalized / 2);
                weaponProjectile.AddForce(GameManager.ProjMath.trajectoryVectorToHitTarget(transform,target, 500f));
                weaponProjectile.gameObject.GetComponent<ProjectileBehavior>().setOwner(this.gameObject);
            }
        }
    }
}
