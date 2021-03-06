using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    private float deathTimer = 0.0f;
    private bool dead = false;
    private float _current;
    private float current
    {
        get { return _current; }
        set
        {
            if (playerHealthBar != null) playerHealthBar.UpdateHealth(value);
            if (enemyHealthBar != null) enemyHealthBar.GetComponentInChildren<enemyhealthbar>().setHealth(value);
            _current = value;
        }
    }
    private float _max;
    private float max
    {
        get { return _max; }
        set
        {
            if (playerHealthBar != null) playerHealthBar.UpdateMax(value);
            if (enemyHealthBar != null) enemyHealthBar.GetComponentInChildren<enemyhealthbar>().setMaxHealth(value);
            _max = value;
        }
    }

    public HealthBar playerHealthBar;
    public Canvas enemyHealthBarPrefab;
    Canvas enemyHealthBar;
    public float startHealth;
    public float startMax;

    public ParticleSystem bloodPrefab;


    // Start is called before the first frame update
    void Start()
    {
        current = startHealth;
        max = startMax;
        if (gameObject.name == "player" || gameObject.name == "player(Clone)")
        {
            HealthBar hb = GameObject.FindObjectOfType<Canvas>().GetComponentInChildren<HealthBar>();
            playerHealthBar = hb;
            setMax(GameManager.Instance.health);
            current = GameManager.Instance.health;
            playerHealthBar.UpdateHealth(current);
            playerHealthBar.UpdateMax(current);
        }else{
            current += Random.Range(0, GameManager.Instance.Difficulty * 1.5f);

            enemyHealthBar = Instantiate(enemyHealthBarPrefab);
            enemyHealthBar.transform.parent = transform;
            enemyHealthBar.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
            enemyHealthBar.transform.localPosition = new Vector3(0,1.25f,0);
            enemyHealthBar.GetComponentInChildren<enemyhealthbar>().setMaxHealth(current);
            enemyHealthBar.GetComponentInChildren<enemyhealthbar>().setHealth(current);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dead && gameObject.layer == 6)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer > 5.0f)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public float takeDamage(float damage)
    {
        if (current < damage) current = 0;
        else current -= damage;
        if (current <= 0.5f)
        {
            isDead();
        }
        if (gameObject.layer == 7 && !isAlive())
        {
            Destroy(this.gameObject);
        }
        ParticleSystem blood = Instantiate(bloodPrefab);
        blood.transform.rotation = Quaternion.Euler(-90, 0, 0);
        blood.transform.position = transform.position;
        blood.Play();
        return current;
    }

    public float takeDamage(float damage, Vector2 knockback)
    {
        RageController rc;
        try
        {
            rc = GetComponent<RageController>();
        }
        catch
        {
            rc = null;
        }
        if (rc != null)
        {
            if (!rc._isRaging)
            {
                takeDamage(damage);
                GetComponent<Rigidbody2D>().AddForce(knockback);
            }
            else
            {
                rc._rage -= (damage * 5f);
            }
        }
        else
        {
            takeDamage(damage);
            GetComponent<Rigidbody2D>().AddForce(knockback);
        }
        return current;
    }

    public void heal(float healing)
    {
        if (current + healing > max) current = max;
        else current += healing;
    }

    public void setMax(float newMax)
    {
        max = newMax;
    }

    public bool isAlive()
    {
        return current >= 0.5f;

    }
    public void isDead()
    {
        dead = true;
    }

    public float currentHealth()
    {
        return current;
    }
}
