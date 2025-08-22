using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : ACBehaviour
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
    public void BXLoadPage(int pageNum)
    {
        ACExecAfterFrames(5, () => {
            GetCurrentPage().SetActive(false);
            SetPage(pageNum);
        });
        
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

    private void OnEnable() => Cursor.lockState = CursorLockMode.Confined;
    private void OnDisable() => Cursor.lockState -= CursorLockMode.Locked;
}
