using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    private Stack<GameObject> menus = new Stack<GameObject>();
    public GameObject mainMenu;
    private GameObject currentMenu;

    float popupTime = 1f;
    float popupTimeCounter = 5f;

    private void Awake() {
        currentMenu = mainMenu;
    }

    void Update(){
        popupTimeCounter += Time.deltaTime;
    }

    void OnGUI(){
        if(popupTimeCounter < popupTime){
            GUIStyle headStyle = new GUIStyle();
            headStyle.fontSize = 100;
            headStyle.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2-400, Screen.height / 2 - 200, 100, 50), "Please Come back later", headStyle);
            GUI.Label(new Rect(Screen.width / 2-600, Screen.height / 2 + 200, 100, 50), "Overscoped and under prepared", headStyle);
            GUIStyle headStyle1 = new GUIStyle();
            headStyle1.fontSize = 101;
            headStyle1.normal.textColor = Color.white;
            GUI.Label(new Rect(Screen.width / 2-405, Screen.height / 2 - 195, 100, 50), "Please Come back later", headStyle1);
            GUI.Label(new Rect(Screen.width / 2-605, Screen.height / 2 + 195, 100, 50), "Overscoped and under prepared", headStyle1);
        }
    }

    public void OpenMenu(GameObject menu) {
        popupTimeCounter = 0;
        // // Store current menu on the stack
        // menus.Push(currentMenu);
        // // Close menu
        // currentMenu.SetActive(false);

        // // Open new menu
        // menu.SetActive(true);
        // currentMenu = menu;
    }

    public void CloseMenu() {
        // Close current
        currentMenu.SetActive(false);
        // Get new menu
        currentMenu = menus.Pop();
        // Open new
        currentMenu.SetActive(true);
    }
}
