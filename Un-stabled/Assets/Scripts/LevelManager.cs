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

    [SerializeField]
    AudioClip[] music;

    [SerializeField]
    AudioSource speaker;

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
        speaker = GetComponent<AudioSource>();
        speaker.clip = music[0];
        speaker.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!speaker.isPlaying && speaker.clip == music[0]){
            speaker.clip = music[1];
            speaker.loop = true;
            speaker.Play();
        }
    }
}
