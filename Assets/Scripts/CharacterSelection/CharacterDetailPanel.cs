using Characters;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelection
{
    public class CharacterDetailPanel: MonoBehaviour
    {
        [SerializeField]
        private Text nameLabel;
        [SerializeField]
        private Text lifepointsLabel;
        [SerializeField]
        private Text attackpointsLabel;
        [SerializeField]
        private Text defensepointsLabel;
        [SerializeField]
        private Image portrait;
        private CharacterData character;

        public static CharacterDetailPanel Instance
        {
            get; private set;
        }

        private void Awake ()
        {
            Instance = this;
        }

        private void Start ()
        {
            Hide ();
        }

        public void Show (CharacterData character)
        {
            this.character = character;
            nameLabel.text = character.name;
            lifepointsLabel.text = character.lifepoints.ToString ();
            attackpointsLabel.text = character.attackpoints.ToString ();
            defensepointsLabel.text = character.defensepoints.ToString ();
            portrait.sprite = character.portrait;
            gameObject.SetActive (true);
        }

        public void Hide ()
        {
            gameObject.SetActive (false);
        }

        public void RemoveCurrentCharacter ()
        {
            TeamManager.Instance.RemoveCharacter (character);
            Hide ();
        }
    }
}