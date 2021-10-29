using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fathergame.Managers
{
    public class PlayerTransformManager : MonoBehaviour
    {
        [System.Serializable]
        public struct PlayerNameAndModel
        {
            public string Name;
            public Transform Model;
        }
        public PlayerNameAndModel[] PlayerNameAndModels;

        private Dictionary<int, PlayerNameAndModel> _playerLevels = new Dictionary<int, PlayerNameAndModel>();

        private int plylevel;

        public Transform Citizen, ActiveCharacter, SelectedWeapon;

        private void Start()
        {
            ActiveCharacter = Citizen;
            _playerLevels.Add(1, PlayerNameAndModels[0]);
            _playerLevels.Add(-1, PlayerNameAndModels[1]);
        }

        public void ManagePlayerTransform()
        {
            if (GameManager.Instance.Points >= 10)
            {
                plylevel++;
                ManagersHolder.UiManager.PlayerHeadText.text = _playerLevels[plylevel].Name;
                ManagersHolder.UiManager.FillBar.color = Color.blue;
                GameManager.Instance.Points -= 10;
                ChangeModel();
            }
            else if (GameManager.Instance.Points <= -10)
            {
                plylevel--;
                ManagersHolder.UiManager.PlayerHeadText.text = _playerLevels[plylevel].Name;
                ManagersHolder.UiManager.FillBar.color = Color.red;
                GameManager.Instance.Points += 10;
                ChangeModel();
            }
        }

        private void ChangeModel()
        {
            ActiveCharacter.gameObject.SetActive(false);
            _playerLevels[plylevel].Model.gameObject.SetActive(true);
            ActiveCharacter = _playerLevels[plylevel].Model;
        }
    }
}
