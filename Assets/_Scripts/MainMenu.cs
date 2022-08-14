using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public void LoadGamePress()
    {
        FindObjectOfType<SceneManagerScript>().LoadGame();
    }

    private void Start()
    {
        scoreText.text = ScoreKeeper.GetScore().ToString();
    }
}
