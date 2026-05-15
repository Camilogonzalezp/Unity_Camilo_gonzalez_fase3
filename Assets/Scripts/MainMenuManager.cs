using UnityEngine;
using UnityEngine.SceneManagement;

// Clase principal del menú
public class MainMenuManager : MonoBehaviour
{
    // Panel de controles
    public GameObject controlsPanel;

    // Panel how to play
    public GameObject howToPlayPanel;

    // Panel exit
    public GameObject exitPanel;

    // Audio del menú
    public AudioSource buttonSound;

    // Función para reproducir sonido
    void PlayButtonSound()
    {
        buttonSound.Play();
    }

    // Iniciar juego
    public void StartGame()
    {
        PlayButtonSound();
        SceneManager.LoadScene("SampleScene");
    }

    // Abrir controles
    public void OpenControls()
    {
        PlayButtonSound();
        controlsPanel.SetActive(true);
    }

    // Cerrar controles
    public void CloseControls()
    {
        PlayButtonSound();
        controlsPanel.SetActive(false);
    }

    // Abrir how to play
    public void OpenHowToPlay()
    {
        PlayButtonSound();
        howToPlayPanel.SetActive(true);
    }

    // Cerrar how to play
    public void CloseHowToPlay()
    {
        PlayButtonSound();
        howToPlayPanel.SetActive(false);
    }

    // Abrir exit panel
    public void OpenExitPanel()
    {
        PlayButtonSound();
        exitPanel.SetActive(true);
    }

    // Cerrar exit panel
    public void CloseExitPanel()
    {
        PlayButtonSound();
        exitPanel.SetActive(false);
    }

    // Salir del juego
    public void ExitGame()
    {
        PlayButtonSound();

        Application.Quit();

        Debug.Log("Game Closed");
    }
}