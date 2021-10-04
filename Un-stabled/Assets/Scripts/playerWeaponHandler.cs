using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeaponHandler : MonoBehaviour
{

    public GameObject hand;
    public GameObject melee;
    public GameObject projectile;
    public GameObject gun;

    GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
