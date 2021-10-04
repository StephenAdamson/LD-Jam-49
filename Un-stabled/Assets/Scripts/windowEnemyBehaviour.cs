using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowEnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    float hideTime = 2;
    [SerializeField]
    float outTime = 2;
    [SerializeField]
    int shotCount = 3;

    float elapsedTime;

    bool hidden = true;

    float shootTime;

    [SerializeField]
    Sprite inSprite;
    [SerializeField]
    Sprite outSprite;
    [SerializeField]
    Sprite enemySprite;

    [SerializeField]
    Rigidbody2D weaponProjectile;
    [SerializeField]
    Rigidbody2D bulletProjectile;
    [SerializeField]
    Transform target;


    CircleCollider2D col;
    GameObject windowChild;
    GameObject enemyChild;
    SpriteRenderer[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        elapsedTime = 0;
        shootTime = (float)(outTime-0.01f)/(float)shotCount;
        sprites = this.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hidden){
            if (elapsedTime == 0)
            {
                sprites[0].sprite = inSprite;
                sprites[1].sprite = null;
                col.enabled = false;
            }
            if(elapsedTime > hideTime){
                elapsedTime = 0;
                hidden = !hidden;
                return;
            }
        }else
        {
            if (elapsedTime == 0)
            {
                sprites[0].sprite = outSprite;
                sprites[1].sprite = enemySprite;
                col.enabled = true;
            }
            if (elapsedTime > outTime)
            {
                elapsedTime = 0;
                hidden = !hidden;
                return;
            }

            if (elapsedTime % shootTime > .5 && (elapsedTime + Time.deltaTime) % shootTime < .5)
            {
                if (target)
                {
                    if (weaponProjectile != null)
                    {
                        Vector3 targetAim = target.position;
                        targetAim += (Vector3.up * Random.Range(1f,3f));
                        Rigidbody2D wp = Instantiate(weaponProjectile);
                        wp.transform.position = transform.position - ((transform.position - target.position).normalized / 2);
                        wp.AddForce(GameManager.ProjMath.trajectoryVectorToHitTarget(transform.position,targetAim, 500f));
                        wp.gameObject.GetComponent<ProjectileBehavior>().setOwner(this.gameObject);
                    }
                    else if (bulletProjectile)
                    {
                        Vector3 dir = -(transform.position - (target.position + new Vector3(0, Random.Range(-1.5f, 1.5f), 0))).normalized;
                        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 10f);
                        if (hit.collider.gameObject.layer == 6)
                        {
                            hit.collider.gameObject.GetComponent<HealthController>().takeDamage(1);
                        }
                        Rigidbody2D wp = Instantiate(bulletProjectile);
                        wp.transform.position = transform.position - ((transform.position - target.position).normalized / 2);
                        wp.AddForce(dir * 10000f);
                    }
                }
            }
        }
        elapsedTime += Time.deltaTime;
    }
}