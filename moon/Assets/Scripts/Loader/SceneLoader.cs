using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loader
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            StartCoroutine(StartLoadRoutine(sceneName));
        }
        
        private static IEnumerator StartLoadRoutine(string sceneName)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                yield break;
            }
            
            var waitNextScene = SceneManager.LoadSceneAsync(sceneName);
            while (!waitNextScene.isDone)
            {
                yield return null;    
            }
        }
    }
}