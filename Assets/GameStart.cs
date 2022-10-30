using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public Animator startPanel;
    public GameObject light;
    public void LoadGame()
    {
        StartCoroutine(HoldTo_Start());
    }

    IEnumerator HoldTo_Start()
    {
       
        light.SetActive(true);
        yield return new WaitForSeconds(0.35f);

        startPanel.SetTrigger("gameStartPanelOpen");
        yield return new WaitForSeconds(0.2f);
        LoadGame2();
    }

    void LoadGame2()
    {

        SceneManager.LoadScene(1);
    }
}
