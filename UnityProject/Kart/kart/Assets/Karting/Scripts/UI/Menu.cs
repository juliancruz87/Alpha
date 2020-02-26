using System.Collections;
using System.Collections.Generic;
using KartGame.Track;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    private TrackManager m_TrackManager;

    void Start()
    {
        menu.SetActive(false);
        m_TrackManager = FindObjectOfType<TrackManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_TrackManager.CanEndRace() && !menu.activeSelf) 
            menu.SetActive(true);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
