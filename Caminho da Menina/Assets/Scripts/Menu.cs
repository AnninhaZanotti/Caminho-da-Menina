using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string nomeCena;
    public GameObject menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        //ativando painel do menu
        menuPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //funcao do botao start
    public void StartGame()
    {
        //carregando a cena Game
        SceneManager.LoadScene(nomeCena);
    }
    public void QuitGame()
    {
        //jogo rodando na Unity
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
