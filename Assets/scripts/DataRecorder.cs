using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DataRecorder : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject gamemanager;
    public GameData gameData;

    float recordTimer = 0; 

    public float recordEvery = 1f; 

    private void Awake()
    {
        gameData = new GameData();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recordTimer += Time.deltaTime;
        if (recordEvery < recordTimer)
        {
            recordTimer = 0;

            PlayerData data = new PlayerData();
            data.posX = player.transform.position.x;
            data.score = player.dodgerAttributes.getcurrentScore();
            data.health = player.dodgerAttributes.getcurrenthealth();

            gameData.entries.Add(data);
        }
    }
}
