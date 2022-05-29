using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public GameObject[] liveSprites;

    private void OnEnable()
    {
        GameLogic.OnLivesChanged += UpdateLives;
    }

    private void OnDisable()
    {
        GameLogic.OnLivesChanged -= UpdateLives;
    }

    private void UpdateLives(int lives)
    {
        // hacking up to 3 lives only
        lives = Mathf.Clamp(lives, 0, 3);

        for (int i = 0; i < liveSprites.Length; i++)
        {
            liveSprites[i].SetActive(i < lives);
        }
    }
}