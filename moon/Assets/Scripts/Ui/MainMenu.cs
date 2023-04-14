using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class MainMenu : MonoBehaviour
    {
        public void OnNewGameButtonClicked(string sceneName)
        {
            StartCoroutine(LoadScene(sceneName));
        }

        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
        
        private static IEnumerator LoadScene(string nextScene)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                yield break;
            }
            
            var waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            while (!waitNextScene.isDone)
            {
                yield return null;    
            }
        }
    }
}