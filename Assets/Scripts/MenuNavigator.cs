using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigator : MonoBehaviour
{
    
    public GameObject[] menus;
    public Menus currentMenu;

    public void ChangeMenu(Menus menu)
    {
        menus[(int)currentMenu].SetActive(false);
        menus[(int)menu].SetActive(true);
        currentMenu = menu;
    }

    public void ChangeMenu(int menu)
    {
        ChangeMenu((Menus)menu);
    }

    public void CloseAllMenus()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }

    public void OpenMainMenu()
    {
        menus[0].SetActive(true);
    }
}

public enum Menus{
    Main = 0,
    Settings = 1,

    Gallery = 2,

    More = 3
}
