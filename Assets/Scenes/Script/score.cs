using TMPro;
using UnityEngine;
[System.Serializable]
public struct scoreText
{
    public TextMeshProUGUI text;
    public int value;
    
}

public class score : MonoBehaviour
{
    //This file contains functions that change and manage inventory item value.
    //Each item is distinguisable by their index value in the array.
    [SerializeField]
    scoreText[] varScore;
    public void AddScore(int i)
    {
        //When this function is called, increase the value of the item with index value i by 1.
        varScore[i].value++;
        varScore[i].text.text = varScore[i].value.ToString();
    }
}
