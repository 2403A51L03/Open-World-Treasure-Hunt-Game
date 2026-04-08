using UnityEngine.SceneManagement; // This is the missing line
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI References")]
    public GameObject winPanel;
    public GameObject losePanel; // New: Create a Lose UI panel
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI timerText;

    [Header("Game Settings")]
    public bool isFreeMode = false;
    public float timeRemaining;
    private bool isGameActive = true;

    public int itemsToWin;
    private int currentItems = 0;

    void Awake() { instance = this; }

    void Update()
    {
        // Only run the timer if we are NOT in free mode and the game is active
        if (!isFreeMode && isGameActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else if (timeRemaining <= 0)
            {
                GameOver();
            }
        }
    }

    public void SetTotalChests(int amount, float calculatedTime)
    {
        itemsToWin = amount;
        if (!isFreeMode) timeRemaining = calculatedTime;
        else timerText.text = "Free Mode";

        UpdateUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ItemCollected()
    {
        currentItems++;
        UpdateUI();
        if (currentItems >= itemsToWin) WinGame();
    }

    void UpdateUI() { statusText.text = $"Chests Found: {currentItems} / {itemsToWin}"; }

    void WinGame()
    {
        isGameActive = false;
        winPanel.SetActive(true);
        EndGameSetup();
    }

    void GameOver()
    {
        isGameActive = false;
        losePanel.SetActive(true);
        EndGameSetup();
    }

    void EndGameSetup()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // 1. CRITICAL: Reset time before loading, or the new scene will be frozen
        Time.timeScale = 1f;

        // 2. Ensure the cursor is locked back for the player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 3. Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}