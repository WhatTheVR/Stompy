using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMangager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D foot;
    [SerializeField] private string targetUrl = "https://google.com";
    public void startPressed()
    {
        StartCoroutine(WaitAndLoad((float)1.5));
    }
    public void settingsPressed()
    {
        SceneManager.LoadScene("settings");
    }
    public void savePressed()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void retryPressed()
    {
        SceneManager.LoadScene("gameplay");
    }
    public void mainMenuPressed()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void quitPressed()
    {
        Application.Quit();
    }
    public void itchPressed()
    {
        Application.OpenURL(targetUrl);
    }

    IEnumerator WaitAndLoad(float time)
    { 
        foot.WakeUp();
        
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("gameplay");
    }

}
