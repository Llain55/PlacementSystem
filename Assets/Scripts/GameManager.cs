using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject basicHouseLVL1;
    public GameObject basicHouseLVL2;
    public GameObject basicHouseLVL3;
    public Text coinsText;
    public int coins = 100;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {
        basicHouseLVL1.SetActive(false);
        basicHouseLVL2.SetActive(false);
        basicHouseLVL3.SetActive(false);
        coinsText.text = coins.ToString();
        counter = 200f;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter <= 0 )
        {
            if (basicHouseLVL1.activeSelf)
            {
                coins = coins + 100;
                counter = 500f;
            }
            else if (basicHouseLVL2.activeSelf)
            {
                coins = coins + 350;
                counter = 750f;
            }
            else if (basicHouseLVL3.activeSelf)
            {
                coins = coins + 600;
                counter = 1000;
            }
            else
            {
                coins++;
                counter = 200f;
            }
            coinsText.text = coins.ToString();  
        }
        counter--;
    }

    public void Place()
    {
        if(basicHouseLVL1.activeSelf == false && basicHouseLVL2.activeSelf == false && basicHouseLVL3.activeSelf == false && coins>= 100)
        {
            basicHouseLVL1.SetActive(true);
            coins = coins - 100;
            coinsText.text = coins.ToString();
        }
    }

    public void Upgrade()
    {

        if (basicHouseLVL1.activeSelf && coins >= 500)
        {
            basicHouseLVL1.SetActive(false);
            basicHouseLVL2.SetActive(true);
            coins = coins - 500;
            coinsText.text = coins.ToString();
        }
        else if (basicHouseLVL2.activeSelf && coins >= 2000)
        {
            basicHouseLVL2.SetActive(false);
            basicHouseLVL3.SetActive(true);
            coins = coins - 2000;
            coinsText.text = coins.ToString();
        }
    }

    public void Demolish()
    {
        basicHouseLVL1.SetActive(false);
        basicHouseLVL2.SetActive(false);
        basicHouseLVL3.SetActive(false);
    }
}
