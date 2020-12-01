using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> spawnitems = new List<GameObject>();
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject[] spawns;
    public GameObject NextWave;
    Text mytext;

    int waveNumber = 0;
    public float nextspawn = 0.0F;

    void Start()
    {
        mytext = GetComponent<Text>();
    }

    void Update()
    {
        spawns = GameObject.FindGameObjectsWithTag("Enemy");
        if (spawns.Length == 0)
        {
            NextWave.SetActive(true);
            if (Input.GetKeyDown(KeyCode.N))
            {
                NextWave.SetActive(false);
                next_wave();
            }
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
        if (waveNumber == 1 || waveNumber == 2)
        {
            spawn_mob(waveNumber + 1,2); // ilosc, typ
        }
        if (waveNumber >= 3)
        {
            spawn_mob(waveNumber,2); // ilosc typ
            spawn_mob(waveNumber - 2,0); // ilosc typ
        }
    }

    public void spawn_mob(int amount, int number)
    {
        for (int i = 0; i < spawners.Count; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                Instantiate(spawnitems[number], spawners[i].transform.position + new Vector3(0, 0, -10), spawners[i].transform.rotation);
            }
        }        
    }
}