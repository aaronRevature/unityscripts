using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour { 
    public void Scene1()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("menuScreen");
    }
    public void roosterCoopLoad()
    {
        SceneManager.LoadScene("ROOSTERCOOP");
    }
    public void arShotLoad()
    {
        SceneManager.LoadScene("ARShot");
    }
    public void dynoBlastLoad()
    {
        SceneManager.LoadScene("Play");
    }
    public void baccaratLoad()
    {
        SceneManager.LoadScene("BACCARATDESKTOP");
    }
    public void fyshForFish() 
    {
      SceneManager.LoadScene("FyshForFish");
    }
    public void fyshNewGame()
    {
        SceneManager.LoadScene("fyshscene");
    }
}   

                                           