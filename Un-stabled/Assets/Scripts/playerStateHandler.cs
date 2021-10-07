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
            GetComponentInChildren<playerWeaponHandler>().dropWeapon();
            GetComponentInChildren<pointAt>().enabled = false;
            anim.SetBool("walking",false);
            GetComponent<SpriteRenderer>().color = new Color(255,0,0);

            ParticleSystem blood = Instantiate(bloodPrefab);
            blood.transform.rotation = Quaternion.Euler(-90, 0, 0);
            blood.transform.position = transform.position;
            blood.Play();
        }
        lastHealth = health.currentHealth();
    }

    void OnGUI()
    {
        if (!health.isAlive())
        {
            GUIStyle headStyle2 = new GUIStyle();
            headStyle2.fontSize = 51;
            headStyle2.normal.textColor = Color.white;
            // headStyle.
            GUI.Label(new Rect(Screen.width / 2 - 205, Screen.height / 2 - 3, 100, 50), "You Died", headStyle2);
            GUI.Label(new Rect(Screen.width / 2 - 505, Screen.height / 2 + 200 - 3, 100, 50), "Upgrade on the main menu!", headStyle2);

            GUIStyle headStyle = new GUIStyle();
            headStyle.fontSize = 50;
            // headStyle.
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2, 100, 50), "You Died", headStyle);
            GUI.Label(new Rect(Screen.width / 2 - 500, Screen.height / 2 + 200, 100, 50), "Upgrade on the main menu!", headStyle);
        }
    }
}
 