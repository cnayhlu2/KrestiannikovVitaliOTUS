using UnityEngine;

namespace Homework_06_Conveyor
{
    public class ConveyorProgressView : MonoBehaviour
    {
        [SerializeField] private ProgressBar progressBar;
        [SerializeField] private GameObject root;

        public void SetVisible(bool state)
        {
            this.root.SetActive(state);
        }
        
        public void SetProgress(float progress) => progressBar.SetProgress(progress);

    }
}