using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public static float kills = 0;
    public Text killsText;
    // Start is called before the first frame update
    void Start()
    {
        killsText.text = "Kills : " + kills;
    }

    // Update is called once per frame
    void Update()
    {
        killsText.text = "Kills : " + kills;
    }

    public static void addKills(float numberOfKills)
    {
        kills += numberOfKills;
    }
}
