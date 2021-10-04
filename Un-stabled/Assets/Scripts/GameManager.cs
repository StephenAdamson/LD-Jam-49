using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private static UpgradeManager _upgrades;
    public static UpgradeManager Upgrades { get { return _upgrades; } }

    private static projectileHelper _projMath;
    public static projectileHelper ProjMath { get { return _projMath; } }

    public GameObject prefab;

    public LevelManager lm;

    [Range(0f,1f)]
    public float Difficulty = 0.5f;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            //DontDestroyOnLoad(this.gameObject);
            _instance = this;
            _upgrades = this.gameObject.AddComponent<UpgradeManager>();
            _projMath = this.gameObject.AddComponent<projectileHelper>();
        }
    }

    
    void Start(){

    }

    public void setLevelManager(LevelManager lm){
        this.lm = lm;
    }

    public GameObject getPlayer(){
        return lm.ActivePlayer;
    }

    public void StartGame() {
        SceneManager.LoadScene("test1");
    }

    public void Quit() {
        Application.Quit(0);
    }

    public bool difficultyRoll(){
        return Random.Range(0f,1f) < Difficulty;
    }
}