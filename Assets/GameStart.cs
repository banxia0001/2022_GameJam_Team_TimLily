using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public Animator startPanel;
    public void LoadGame()
    {
        StartCoroutine(HoldTo_Start());
    }

    IEnumerator HoldTo_Start()
    {
        startPanel.SetTrigger("gameStartPanelOpen");
        yield return new WaitForSeconds(0.2f);
        LoadGame2();
    }

    void LoadGame2()
    {

        SceneManager.LoadScene(1);
    }
}
