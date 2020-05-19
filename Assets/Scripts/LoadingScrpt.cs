using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScrpt : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {

        yield return new WaitForSeconds(5.0f);
        StartCoroutine(LoadAsyncOperation());
    }

   IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2);
       
        yield return new WaitForEndOfFrame();
    }
}
