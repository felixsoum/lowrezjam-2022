using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Image[] numbers;
    [SerializeField] Sprite[] numberSprites;
    bool isLoading;

    public void LoadGamePress()
    {
        if (isLoading)
        {
            return;
        }
        isLoading = true;
        FindObjectOfType<SceneManagerScript>().LoadGame();
    }

    private void Start()
    {
        if (numbers != null && numbers.Length > 0)
        {
            int score = ScoreKeeper.GetScore();
            for (int i = 0; i < 4; i++)
            {
                numbers[i].sprite = numberSprites[score % 10];
                score /= 10;
            }
        }
    }
}
