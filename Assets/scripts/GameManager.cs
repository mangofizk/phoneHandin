using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    [SerializeField] float spawnRate;

    bool gamestart = false;

    int score = 0;

    Vector2 screenPos;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI startText;

    [SerializeField] Player player;
   
    void SpawnEnemy()
    {
        float randomX = Random.Range(0f, 1f);

        Vector2 viewPortPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);

        Instantiate(enemyPrefab, worldPos,Quaternion.identity);

        score++;
        UpdateText(score);
        player.dodgerAttributes.setcururrentscore(score);
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, spawnRate);
    }

    private void Update()
    {
        if (transform.GetComponent<InputSys>().IsPressing(out screenPos) && !gamestart)
        {
            StartSpawning();
            gamestart = true;
            Destroy(startText);
        }

        Debug.Log("Current Score:" + score);
    }

    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }
}
