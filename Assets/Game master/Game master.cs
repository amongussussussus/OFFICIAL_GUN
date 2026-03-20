using TMPro;
using UnityEngine;

public class Gamemaster : MonoBehaviour
{
    [SerializeField] GameObject dropazone;
    [SerializeField] GameObject soil_1, soil_2, soil_3;
    int player_score = 0;
    [SerializeField] TextMeshPro score;

    private float timer = 20f;
    void Awake()
    {
    }
    void FixedUpdate()
    {
        timer -= 1*Time.deltaTime;
        score.text = "Your score: " + player_score;
    }
    void Update()
    {
        if(timer<=0)
        {
            Vector2 location = dropazone.transform.position;
            int enemy_number = Random.Range(2,10);
            for(int i = 0; i<enemy_number;i++)
            {
            location += new Vector2(1,0);
            int enemy_index = Random.Range(1,4);
            switch (enemy_index)
            {
                case 1:
                    GameObject enemy_0 = Instantiate(soil_1, location, dropazone.transform.rotation);
                    break;
                case 2:
                    GameObject enemy_1 = Instantiate(soil_2, location, dropazone.transform.rotation);
                    break;
                case 3:
                    GameObject enemy_2 = Instantiate(soil_3, location, dropazone.transform.rotation);
                    break;
            }
            }
            timer = 20;
        }
    }
    public void PlayerScore(int score)
    {
        player_score += score;
    }
}
