using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NexusMeneger : MonoBehaviour
{
    public Text mytext;
    public GameObject lose;
    int hp = 20;

    void Start()
    {
        mytext.text = "NEXUS HEALTH:" + hp;
    }

    void Update()
    {
        Lose();
    }

    private void Lose()
    {
        if (hp == 0)
        {
            //Debug.Log("You're looser");
            lose.SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hp--;
            mytext.text = "NEXUS HEALTH:" + hp;
            Debug.Log("Kolizja z nexusem");
        }
    }
}
