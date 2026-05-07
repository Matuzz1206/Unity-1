using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private int totalPickups = 0;
    private int collectedPickups = 0;

    private bool p1InGoal = false;
    private bool p2InGoal = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main Level")
        {
            p1InGoal = false;
            p2InGoal = false;
            collectedPickups = 0;

            StartCoroutine(CountPickupsDelayed());
        }
    }

    IEnumerator CountPickupsDelayed()
    {
        yield return null;
        CountPickups();
    }

    private void CountPickups()
    {
        int p1 = GameObject.FindGameObjectsWithTag("P1Only").Length;
        int p2 = GameObject.FindGameObjectsWithTag("P2Only").Length;
        int both = GameObject.FindGameObjectsWithTag("Both").Length;

        totalPickups = p1 + p2 + both;

        Debug.Log("TOTAL PICKUPS FOUND = " + totalPickups);
    }

    public void PickupCollected()
    {
        collectedPickups++;
        Debug.Log("Collected: " + collectedPickups + " / " + totalPickups);
        CheckWinCondition();
    }

    public void PlayerEnteredGoal(string playerTag)
    {
        if (playerTag == "Player1") p1InGoal = true;
        if (playerTag == "Player2") p2InGoal = true;

        CheckWinCondition();
    }

    public void PlayerExitedGoal(string playerTag)
    {
        if (playerTag == "Player1") p1InGoal = false;
        if (playerTag == "Player2") p2InGoal = false;
    }

    private void CheckWinCondition()
    {
        // Prevent instant win if totalPickups was not counted yet
        if (totalPickups <= 0)
        {
            Debug.Log("NO PICKUPS COUNTED — WIN DISABLED");
            return;
        }

        if (!p1InGoal || !p2InGoal)
        {
            Debug.Log("Both players NOT in goal");
            return;
        }

        if (collectedPickups < totalPickups)
        {
            Debug.Log("Not all pickups collected");
            return;
        }

        Debug.Log("WIN CONDITION MET — LOADING WIN SCENE");
        StartCoroutine(LoadWinScene());
    }

    IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("Win");
    }
}