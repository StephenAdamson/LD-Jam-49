using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    float endTime = 5f;
    float endTimeCounter = 0f;
    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(done){
            endTimeCounter += Time.deltaTime;
        }
        if(endTimeCounter > endTime){
            SceneManager.LoadScene("MainMenu");
            GameManager.Instance.Difficulty += .1f;
            GameManager.Instance.level += Random.Range(0,1);
            GameManager.Instance.health += Random.Range(0,1);
        }
    }

    void OnGUI(){
        if(done){
            GUIStyle headStyle = new GUIStyle();
            headStyle.fontSize = 100;
            headStyle.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2-400, Screen.height / 2 - 200, 100, 50), "You took over the Farm", headStyle);
            GUI.Label(new Rect(Screen.width / 2-600, Screen.height / 2 + 200, 100, 50), "Replay for a harder chalenge", headStyle);
            GUI.Label(new Rect(Screen.width / 2-600, Screen.height / 2 + 300, 100, 50), "with a chance of new weapons", headStyle);
            GUI.Label(new Rect(Screen.width / 2-300, Screen.height / 2 + 400, 100, 50), "and more health", headStyle);
            GUIStyle headStyle1 = new GUIStyle();
            headStyle1.fontSize = 101;
            headStyle1.normal.textColor = Color.white;
            GUI.Label(new Rect(Screen.width / 2-405, Screen.height / 2 - 195, 100, 50), "You took over the Farm", headStyle1);
            GUI.Label(new Rect(Screen.width / 2-605, Screen.height / 2 + 195, 100, 50), "Replay for a harder chalenge", headStyle1);
            GUI.Label(new Rect(Screen.width / 2-605, Screen.height / 2 + 295, 100, 50), "with a chance of new weapons", headStyle1);
            GUI.Label(new Rect(Screen.width / 2-305, Screen.height / 2 + 395, 100, 50), "and more health", headStyle1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 6) done = true;

    }
}
