using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{

    public List<GameObject> spawnitems = new List<GameObject>();
    public List<GameObject> spawners = new List<GameObject>();
    Text mytext;
    int waveNumber = 0;

    void Start()
    {
        mytext = GetComponent<Text>();
    }

    void Update()
    {
        NextWaveTrigger();
    }

    private void NextWaveTrigger()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            next_wave();
        }
    }

    public void current_wave()
    {
    mytext.text = waveNumber.ToString();
    }

    public void next_wave()
    {
        waveNumber++;
        current_wave();
        spawn_wave();
    }
    public void spawn_wave()
    {
        for (int i = 0; i < spawners.Count; i++)
        {
            Instantiate(spawnitems[0], spawners[i].transform.position, spawners[i].transform.rotation);
        }
        
    }

}
