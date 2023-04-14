using Loader;
using UnityEngine;

namespace Ui
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        
        public void OnNewGameButtonClicked(string sceneName)
        {
            sceneLoader.LoadScene(sceneName);
        }

        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}