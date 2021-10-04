using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeaponHandler : MonoBehaviour
{

    public GameObject[] projectiles;
    public GameObject[] guns;

    public GameObject hand;
    public GameObject melee;
    public GameObject projectile;
    public GameObject gun;

    GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
    setWeapon:
        if (hand)
        {
            if (gun)
            {
                weapon = Instantiate(gun);
                weapon.transform.parent = hand.transform;
                weapon.transform.localPosition = new Vector3(0, 0, 0);
            }
            else if (projectile)
            {
                weapon = Instantiate(projectile);
                weapon.transform.parent = hand.transform;
                weapon.transform.localPosition = new Vector3(0, 0, 0);
            }
            else if (melee)
            {

            }
            else
            {
                int level = GameManager.Instance.level;
                if(level <= projectiles.Length){
                    projectile = projectiles[GameManager.Instance.level - 1];
                    goto setWeapon;
                }
                level -= projectiles.Length;
                if(level <= guns.Length){
                    gun = guns[GameManager.Instance.level - 1];
                    goto setWeapon;
                }
                gun = guns[guns.Length - 1];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
