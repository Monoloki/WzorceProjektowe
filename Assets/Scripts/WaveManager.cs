using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> spawnitems = new List<GameObject>();
    public List<GameObject> spawners = new List<GameObject>();
    Text mytext;
    int waveNumber = 0;
    int i;

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
            spawn_mob1();
        }
    }

    public void spawn_mob1()
    {
            Instantiate(spawnitems[0], spawners[i].transform.position + new Vector3(0, 0, -10), spawners[i].transform.rotation);
    }

    public void spawn_mob2()
    {
            Instantiate(spawnitems[1], spawners[i].transform.position + new Vector3(0, 0, -10), spawners[i].transform.rotation);
    }

    public void spawn_mob3()
    {
            Instantiate(spawnitems[2], spawners[i].transform.position + new Vector3(0, 0, -10), spawners[i].transform.rotation);
    }
}