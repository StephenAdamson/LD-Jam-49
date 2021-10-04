using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float _current;
    private float current{
        get { return _current; }
        set {
            if (healthBar != null) healthBar.UpdateHealth(value);
            _current = value;
        }
    }
    private float _max;
    private float max{
        get { return _max; }
        set {
            if (healthBar != null) healthBar.UpdateMax(value);
            _max = value;
        }
    }

    public HealthBar healthBar;
    public float startHealth;
    public float startMax;

    // Start is called before the first frame update
    void Start()
    {
        current = startHealth;
        max = startMax;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.RightArrow)) heal(1);
        // if(Input.GetKeyDown(KeyCode.LeftArrow)) takeDamage(1);
    }

    public void takeDamage(float damage) {
        if (current < damage) current = 0;
        else current -= damage;
    }

    public void heal(float healing) {
        if (current + healing > max) current = max;
        else current += healing;
    }

    public void setMax(float newMax) {
        max = newMax;
    }

    public bool isAlive() {
        return current > 0;
    }

    public float currentHealth() {
        return current;
    }
}
