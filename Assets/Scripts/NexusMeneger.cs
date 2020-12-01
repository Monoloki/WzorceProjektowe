using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NexusMeneger : MonoBehaviour
{
    public GameObject lose;
    public GameObject bar;
    public GameObject cam;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public int maxHealth = 20;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    void Update()
    {
        Health();
        bar.transform.LookAt(cam.transform);
    }

    private void Health()
    {
        if (currentHealth == 0)
        {
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
            currentHealth--;
            slider.value = currentHealth;
            fill.color = gradient.Evaluate(slider.normalizedValue);
            Debug.Log("Kolizja z nexusem");
        }
    }
}
