using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [SerializeField]
    float distance;
    Transform cm;
    [SerializeField]
    float yHeight;

    [SerializeField]
    float xOffset;


    // Start is called before the first frame update
    void Start()
    {
        cm = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = cm.position;
        pos.x += xOffset;
        pos /= 4f;
        pos.y = yHeight;
        this.transform.position = pos;
    }
}
