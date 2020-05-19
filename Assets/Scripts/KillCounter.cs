using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public static float kills = 0;
    public Text killsText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        kills = 0;
        killsText.text = "KILLS : " + kills;
    }

    // Update is called once per frame
    void Update()
    {
        killsText.text = "KILLS : " + kills;
    }

    public static void addKills(float numberOfKills)
    {
        kills += numberOfKills;
    }

    public void restart()
    {
        
        SceneManager.LoadScene("SampleScene");
        
    }
}
