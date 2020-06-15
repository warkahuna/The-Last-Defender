using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class ApplicationManager : MonoBehaviour {
    private string playStoreId = "3656291";
    private string InterAd = "video";
    private static bool fired = false;
    public bool isTargetPlayStore;
    public bool isTest;

    public void Start()
    {
        AdInit();
    }
    public void Play()
	{
        
        PlayAD();
        if(!Advertisement.isShowing)
        SceneManager.LoadScene(1);
	}
	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

    private void AdInit()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreId, isTest);
            fired = false;
            return;
        }
    }
    private void PlayAD()
    {
        if (!Advertisement.IsReady(InterAd))
        {
            return;
        }
        Advertisement.Show();
        fired = true;
    }
}
