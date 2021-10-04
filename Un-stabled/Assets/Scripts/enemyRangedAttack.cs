using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRangedAttack : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D projectile;
    Transform target;
    [SerializeField]
    Transform emitter;


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
                Vector3 targetAim = target.position;
                targetAim += (Vector3.up * Random.Range(1f,5f));
                Rigidbody2D weaponProjectile = Instantiate(projectile);
                weaponProjectile.transform.position = emitter.position;
                weaponProjectile.AddForce(GameManager.ProjMath.trajectoryVectorToHitTarget(transform.position,targetAim, 500f));
                weaponProjectile.gameObject.GetComponent<ProjectileBehavior>().setOwner(this.gameObject);
            }
        }
    }
}
