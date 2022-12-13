using System.Collections;
using GameElements.Unity;
using Services;
using Services.Unity;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Homework_05_Save_Load.Application
{
    public class ApplicationManager : MonoBehaviour
    {
        [SerializeField] private bool startOnWake = true;

        [SerializeField] private ServiceInstaller serviceInstaller;

        private MonoGameContext gameContext;
        private bool isLoad;

        private void Awake()
        {
            if (startOnWake)
            {
                ApplicationLoad();
            }
        }
        
        private void OnApplicationQuit()
        {
            if (isLoad)
                SaveGameData();
        }

        [Button]
        private void ApplicationLoad()
        {
            if (isLoad)
                return;
            StartCoroutine(LoadingRoutine());
        }

        private IEnumerator LoadingRoutine()
        {
            InstallServices();
            yield return LoadGameScene();
            FindGameContext();
            LoadGameData();
            StartGame();
            this.isLoad = true;
        }

        private void InstallServices()
        {
            this.serviceInstaller.InstallServices();
            ServiceInjector.ResolveDependencies();
        }

        private IEnumerator LoadGameScene()
        {
            const string gameSceneName = "Homeworks/Homework_05_Save_Load/UpgradesScene";
            yield return SceneManager.LoadSceneAsync(gameSceneName, LoadSceneMode.Additive);
        }

        private void FindGameContext()
        {
            this.gameContext = FindObjectOfType<MonoGameContext>();
            this.gameContext.LoadGame();
        }

        private void LoadGameData()
        {
            var dataLoaders = ServiceLocator.GetServices<IGameDataLoader>();
            foreach (var dataLoader in dataLoaders)
            {
                dataLoader.LoadData(this.gameContext);
            }
        }

        private void SaveGameData()
        {
            var dataSavers = ServiceLocator.GetServices<IGameDataSaver>();
            foreach (var dataSaver in dataSavers)
            {
                dataSaver.Save(this.gameContext);
            }
        }

        private void StartGame()
        {
            this.gameContext.InitGame();
            this.gameContext.ReadyGame();
            this.gameContext.StartGame();
        }
    }
}