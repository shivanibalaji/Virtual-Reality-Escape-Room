using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoading : MonoBehaviour
{
    public static SceneLoading instance;
    private void Awake()
    {
        if(instance !=null && instance!= this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
   public void LoadScene(string sceneName)
   {
       StartCoroutine(ShowOverlayAndLoad(sceneName));
   }
   IEnumerator ShowOverlayAndLoad(string sceneName)
   {
       yield return new WaitForSeconds(3f);
       AsyncOperation asyncload = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
       while(!asyncload.isDone)
       {
           yield return null;
       }
       yield return null;
   }
}
