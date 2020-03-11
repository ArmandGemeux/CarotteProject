using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerBoutons : MonoBehaviour
{

    public GameObject poppupPanel;
    public GameObject poppupDialogue;

    // Apparition du canvasArmes
    public void AppearPoppup()
    {
        poppupPanel.SetActive(!poppupPanel.activeSelf);

    }

    // Apparition de l'image Img_Dialogue
    public void AppearDialogue()
    {
        poppupDialogue.SetActive(!poppupDialogue.activeSelf);

    }

    // Va a la scène Game
    public void GotoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Va a la scène Menu
    public void GotoMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // Quitte le jeu
    public void Doquit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

