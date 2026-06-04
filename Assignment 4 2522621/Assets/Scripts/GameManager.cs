using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Orb Settings")]
    public int orbsCollected = 0;
    public int totalOrbs = 5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        orbsCollected = 0;
    }
    public void AddOrb()
    {
        orbsCollected++;
        Debug.Log("Orbs: " + orbsCollected + "/" + totalOrbs);
    }

    public bool CanWin()
    {
        return orbsCollected >= totalOrbs;
    }
    public void Lose()
    {
        Debug.Log("YOU LOSE!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}