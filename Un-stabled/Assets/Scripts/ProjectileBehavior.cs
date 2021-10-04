using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField]
    float damage = 1f;
    GameObject owner;
    [SerializeField]
    bool destroyOnContact = false;
    public bool isPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framehealthBar
    void Update()
    {
        
    }

    public void setOwner(GameObject owner){
        this.owner = owner;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        try{
            if(isPlayer && col.gameObject.layer == 6){
                return;
            }
            if(!isPlayer && col.gameObject.layer == 7){
                return;
            }

            if(!isPlayer && col.gameObject.layer == 6){
                col.gameObject.GetComponent<HealthController>().takeDamage(damage);
                Destroy(this.gameObject);
            }else if(isPlayer && col.gameObject.layer == 7){
                col.gameObject.GetComponent<HealthController>().takeDamage(damage);
                Destroy(this.gameObject);
            }else
            {
                if (destroyOnContact)
                {
                    Destroy(this.gameObject);
                }
            }
        }catch{

        }
    }
}
