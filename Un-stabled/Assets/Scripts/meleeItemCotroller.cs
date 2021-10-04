using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeItemCotroller : MonoBehaviour
{
    Animator anim;
    GameObject owner;
    public bool isPlayer = false;

    public float damage = 1;
    public float knockback = 1;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setOwner(GameObject owner){
        this.owner = owner;
    }

    public void whack(){
        anim.SetTrigger("Whack");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(isPlayer && col.gameObject.layer == 6){
            return;
        }
        if(!isPlayer && col.gameObject.layer == 7){
            return;
        }

        try{
            Vector2 dir = (col.gameObject.transform.position + (Vector3.up/4)) - (transform.position - (Vector3.up/4));
            dir = dir.normalized * knockback;
            if(!isPlayer && col.gameObject.layer == 6){
                col.gameObject.GetComponent<HealthController>().takeDamage(damage,dir);
            }else if(isPlayer && col.gameObject.layer == 7){
                col.gameObject.GetComponent<HealthController>().takeDamage(damage,dir);
            }
        }catch{

        }
    }
}
