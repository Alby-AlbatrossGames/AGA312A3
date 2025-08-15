using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public enum MenuPage { Main, Options, Credits }
    public MenuPage currentPage;
    public GameObject menuMain;
    public GameObject menuOptions;
    public GameObject menuCredits;

    public void Start()
    {
        currentPage = MenuPage.Main;
    }
    public void BXQuitApp() => Application.Quit();
    public void BXLoadScene(string scene) => SceneManager.LoadScene(scene);
    public void BXLoadMenu() => BXLoadScene("Menu");
    public void BXLoadPage(int pageNum)
    {
        GetCurrentPage().SetActive(false);
        SetPage(pageNum);
    }

    private GameObject GetCurrentPage()
    {
        switch (currentPage)
        {
            case MenuPage.Main:
                return menuMain;
            case MenuPage.Options:
                return menuOptions;
            case MenuPage.Credits:
                return menuCredits;
            default: return null;
        }
    }
    private void SetPage(int page)
    {
        switch (page)
        {
            case 0:
                menuMain.SetActive(true);
                currentPage = MenuPage.Main;    // p.0
                return;
            case 1:
                menuOptions.SetActive(true);
                currentPage = MenuPage.Options; // p.1
                return;
            case 2:
                menuCredits.SetActive(true);
                currentPage = MenuPage.Credits; // p.2
                return;
        }
    }
}
