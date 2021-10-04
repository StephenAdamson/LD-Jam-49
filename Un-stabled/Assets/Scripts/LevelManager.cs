using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{

    public GameObject ActivePlayer;
    [SerializeField]
    GameObject playerPrefab;
    public SpriteRenderer rageVignette;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setLevelManager(this);
        if(!ActivePlayer && playerPrefab){
            ActivePlayer = Instantiate(playerPrefab);
            ActivePlayer.transform.position = GameObject.FindGameObjectsWithTag("Respawn")[0].transform.position;
        }
        Camera.main.gameObject.GetComponentInChildren<CinemachineVirtualCamera>().Follow = ActivePlayer.transform;
        rageVignette = Camera.main.gameObject.GetComponentsInChildren<SpriteRenderer>()[1];
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
