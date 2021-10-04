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

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);
            _instance = this;
            _upgrades = this.gameObject.AddComponent<UpgradeManager>();
            _projMath = this.gameObject.AddComponent<projectileHelper>();
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("test1");
    }

    public void Quit() {
        Application.Quit(0);
    }

}
