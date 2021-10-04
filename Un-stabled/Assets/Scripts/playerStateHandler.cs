using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateHandler : MonoBehaviour
{
    PlayerMovement movement;
    CharacterController2D charcont;
    HealthController health;
    Animator anim;
    [SerializeField]
    ParticleSystem bloodPrefab;

    float lastHealth;



    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<HealthController>();
        charcont = GetComponent<CharacterController2D>();
        lastHealth = health.startHealth;
        anim = GetComponent<Animator>();
        bloodPrefab.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(!health.isAlive()){
            movement.enabled = false;
            anim.SetBool("walking",false);
            GetComponent<SpriteRenderer>().color = new Color(255,0,0);

            ParticleSystem blood = Instantiate(bloodPrefab);
            blood.transform.rotation = Quaternion.Euler(-90, 0, 0);
            blood.transform.position = transform.position;
            blood.Play();
        }
        if(health.currentHealth() < lastHealth){
            ParticleSystem blood = Instantiate(bloodPrefab);
            blood.transform.rotation = Quaternion.Euler(-90, 0, 0);
            blood.transform.position = transform.position;
            blood.Play();
        }
        lastHealth = health.currentHealth();
    }
}
 