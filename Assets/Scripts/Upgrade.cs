using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotationSpeed;
    public float limit = 3;
    public float upgradePrice = 10;
    private static bool fired = false;

    public float damage;
    public static float health = 1;
    public float ammunation = 10;
    public float reloadSpeed = 0.5f;
    public float points = 0;

    public float ammunationLvl = 1;
    public float reloadSpeedLvl = 1;
    public float healthLvl = 1;
    public float damageLvl = 1;

    public float ammunationPrice = 10;
    public float reloadSpeedPrice = 10;
    public float healthPrice = 10;
    public float damagePrice = 10;

    public Text ammunationLvlText;
    public Text reloadSpeedLvlText;
    public Text healthLvlText;
    public Text damageLvlText;
    public Text pointsText;
    private string playStoreId = "3656291";
    private string InterAd = "video";

    public bool isTargetPlayStore ;
    public bool isTest;
    public float count = 0;
    public float count2 = 0;
    public GameObject panel;
    void Start()
    {
        AdInit();
        prepareStats();
        points = PlayerPrefs.GetFloat("points");

        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if(count == 1 && count2 == 0)
        {
            points += KillCounter.kills;
            updateStat("points", points);
            updateStatText(pointsText, points, "upgrade points : ");
            count = 0;
            count2 = 1;
        }

        if (health == 0)
        {
            if (!fired)
            {
                PlayAD();
            }
            if (!Advertisement.isShowing)
            {
                count = 1;

                panel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
            
    }

    public static void damagedHp(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
    }

    public void upgradeHealth()
    {
        Debug.Log(healthPrice);
        if (healthLvl <= limit && (points > healthPrice))
        {
            health++;
            updateStat("health", health);
            healthLvl++;
            updateStat("healthLvl", healthLvl);
            updateStatText(healthLvlText, healthLvl, "HEALTH LV");

            reducePoints(healthPrice);

            healthPrice += upgradePrice;

        }
           

    }

    public void upgradeaAmmo()
    {
        if (ammunationLvl <= limit && (points > ammunationPrice))
        {
            ammunation += 10;
            updateStat("ammunation", ammunation);

            ammunationLvl++;
            updateStat("ammunationLvl", ammunationLvl);
            updateStatText(ammunationLvlText, ammunationLvl, "AMMO LV");

            reducePoints(ammunationPrice);

            ammunationPrice += upgradePrice;

        }
          
    }

    public void upgradeaReloadSpeed()
    {
        if (reloadSpeedLvl <= limit && (points > reloadSpeedPrice))
        {
            Debug.Log((reloadSpeedPrice));
            reloadSpeed -= 0.1f;
            updateStat("reloadSpeed", reloadSpeed);

            reloadSpeedLvl++;
            updateStat("reloadSpeedLvl", reloadSpeedLvl);
            updateStatText(reloadSpeedLvlText, reloadSpeedLvl, "reload LV");

            reducePoints(reloadSpeedPrice);

            reloadSpeedPrice += upgradePrice;

        }
            
    }

    public void upgradeaDamage()
    {
        if (damageLvl <= limit && (points > damagePrice))
        {
            damage += 1;
            updateStat("damage", damage);

            damageLvl++;
            updateStat("healthLvl", healthLvl);
            updateStatText(damageLvlText, damageLvl, "attack LV");

            reducePoints(damagePrice);

            damagePrice += upgradePrice;

        }
            
    }

    public void prepareStats()
    {
        if (PlayerPrefs.GetFloat("health") == 0)
        {
            PlayerPrefs.SetFloat("health", health);
        }
        else
        {
            health = PlayerPrefs.GetFloat("health");
        }

        if (PlayerPrefs.GetFloat("damage") == 0)
        {
            PlayerPrefs.SetFloat("damage", damage);
        }
        else
        {
            damage = PlayerPrefs.GetFloat("damage");
        }

        if (PlayerPrefs.GetFloat("reloadSpeed") == 0)
        {
            PlayerPrefs.SetFloat("reloadSpeed", reloadSpeed);
        }
        else
        {
            reloadSpeed = PlayerPrefs.GetFloat("reloadSpeed");
        }

        if (PlayerPrefs.GetFloat("ammunation") == 0)
        {
            PlayerPrefs.SetFloat("ammunation", ammunation);
        }
        else
        {
            ammunation = PlayerPrefs.GetFloat("ammunation");
        }




        if (PlayerPrefs.GetFloat("healthLvl") == 0)
        {
            PlayerPrefs.SetFloat("healthLvl", healthLvl);
        }
        else
        {
            healthLvl = PlayerPrefs.GetFloat("healthLvl");
            healthLvlText.text = "HEALTH LV" + healthLvl;
        }

        if (PlayerPrefs.GetFloat("damageLvl") == 0)
        {
            PlayerPrefs.SetFloat("damageLvl", damageLvl);
        }
        else
        {
            damageLvl = PlayerPrefs.GetFloat("damageLvl");
            damageLvlText.text = "atack LV" + damageLvl;
        }

        if (PlayerPrefs.GetFloat("reloadSpeedLvl") == 0)
        {
            PlayerPrefs.SetFloat("reloadSpeedLvl", reloadSpeedLvl);
        }
        else
        {
            reloadSpeedLvl = PlayerPrefs.GetFloat("reloadSpeedLvl");
            reloadSpeedLvlText.text = "reload LV" + reloadSpeedLvl;
        }

        if (PlayerPrefs.GetFloat("ammunationLvl") == 0)
        {
            PlayerPrefs.SetFloat("ammunationLvl", ammunationLvl);
        }
        else
        {
            ammunationLvl = PlayerPrefs.GetFloat("ammunationLvl");
            ammunationLvlText.text = "ammo LV" + ammunationLvl;
        }



    }

    public void updateStat(string stat,float value)
    {
       PlayerPrefs.SetFloat(stat, value);
    }

    public void updateStatText(Text stat, float value,string text)
    {
        stat.text = text+""+ value;
    }


    public void reducePoints(float value)
    {
        points -= value;
    }

    private void AdInit()
    {
        if (isTargetPlayStore) { Advertisement.Initialize(playStoreId, isTest);
            fired = false;
            return;}
    }
    private void PlayAD()
    {
        if(!Advertisement.IsReady(InterAd))
        {
            return;
        }
        Advertisement.Show();
        fired = true;
    }

}
