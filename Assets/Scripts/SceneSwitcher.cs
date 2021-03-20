using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void MusicToggle()
    {
        if (BgScript.Bginstance.Audio.isPlaying)
        {
            BgScript.Bginstance.Audio.Pause();

        }
        else
        {
            BgScript.Bginstance.Audio.Play();
        }
    }
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2 );
        sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
    }
    public void GpScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
        sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
    }

    public void Instruction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        sfxManager.sfxInstance.Audio.PlayOneShot(sfxManager.sfxInstance.Click);
    }
}
