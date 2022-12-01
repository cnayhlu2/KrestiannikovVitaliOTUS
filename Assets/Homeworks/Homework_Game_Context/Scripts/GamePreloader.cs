using GameElements.Unity;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;


namespace Homework_Game_Context
{
    public class GamePreloader : MonoBehaviour
    {

        [SerializeField, Required] private MonoGameContext gameContext;
        [SerializeField, Tooltip("Time in seconds")] private int wateTime = 3;

        private void Awake()
        {
            this.gameContext.LoadGame();
            this.gameContext.InitGame();
        }

        private void Start()
        {
            StartCoroutine(TimerRoutine());
        }


        private IEnumerator TimerRoutine()
        {
            int timeLeft = wateTime;
            var period = new WaitForSeconds(1);
            while (timeLeft > 0)
            {
                Debug.Log($"{timeLeft--}...");
                yield return period;
            }
            this.gameContext.ReadyGame();
            Debug.Log("Game started");
            this.gameContext.StartGame();
        }

    }
}


