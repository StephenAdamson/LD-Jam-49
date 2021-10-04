using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject[] Enemies;
    public float SpawnRadius;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, SpawnRadius);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.name == "player" || cols[i].gameObject.name == "player(Clone)")
            {
                if (GameManager.Instance.difficultyRoll())
                {
                    GameObject enemy = Instantiate(Enemies[(int)Mathf.Abs(RandomGaussian(-Enemies.Length + 1.4f, Enemies.Length - 0.6f))]);
                    enemy.transform.position = transform.position;
                    try
                    {
                        enemy.GetComponent<EnemyMovement>().target = GameManager.Instance.getPlayer().transform;
                    }
                    catch
                    {

                    }
                    try
                    {
                        enemy.GetComponent<Melee_Movement>().target = GameManager.Instance.getPlayer().transform;
                    }
                    catch
                    {

                    }
                    try
                    {
                        enemy.GetComponentInChildren<Shotgun_AI>().target = GameManager.Instance.getPlayer().GetComponent<Collider2D>();
                    }
                    catch
                    {

                    }
                    try
                    {
                        enemy.GetComponentInChildren<Gun_AI>().target = GameManager.Instance.getPlayer().GetComponent<Collider2D>();
                    }
                    catch
                    {

                    }
                }
                    Destroy(this.gameObject);
                    return;
            }
        }
    }

    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}