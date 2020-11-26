using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> spawnitems = new List<GameObject>();
    public List<GameObject> spawners = new List<GameObject>();
    Text mytext;
    int waveNumber = 0;
    public float nextspawn = 0.0F;

    void Start()
    {
        mytext = GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            next_wave();
        }
    }

    public void next_wave()
    {
        waveNumber++;
        mytext.text = waveNumber.ToString();
        spawn_wave();
    }

    public void spawn_wave()
    {
        for (int i = 0; i < spawners.Count; i++)
        {
            spawn_mob(4,2,i);  //ilosc , id moba
        }
    }

    public void spawn_mob(int amount, int number, int a)
    {
            for (int j = 0; j < amount; j++)
            {
                Instantiate(spawnitems[number], spawners[a].transform.position + new Vector3(0, 0, -10), spawners[a].transform.rotation);
            }       
    }

}