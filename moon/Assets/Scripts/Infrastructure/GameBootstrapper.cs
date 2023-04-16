using Loader;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private const string MenuScene = "MenuScene";
        
        [SerializeField] private SceneLoader sceneLoader;
        
        private void Start()
        {
            sceneLoader.LoadScene(MenuScene);
        }
    }
}