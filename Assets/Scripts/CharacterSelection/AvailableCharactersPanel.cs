using System.Collections.Generic;
using Characters;
using Services;
using UnityEngine;
using UnityRest;

namespace CharacterSelection
{
    public class AvailableCharactersPanel: MonoBehaviour
    {
        [SerializeField]
        private AddCharacterButton prefab;
        [SerializeField]
        private Transform panel;
        [SerializeField]
        private bool forceAvailable;
        [SerializeField]
        private CharacterCatalog catalog;
        private Dictionary<string, AddCharacterButton> buttons;

        private void Awake ()
        {
            buttons = new Dictionary<string, AddCharacterButton> (catalog.characters.Length);
        }

        private void Start ()
        {
            foreach (CharacterData character in catalog.characters)
                SetupNewButton (character);
            if (!forceAvailable)
                ServicesFacade.Instance.GetAvailableCharacters (SetAvailableCharacters);
        }

        private void SetupNewButton (CharacterData character)
        {
            AddCharacterButton button = Instantiate (prefab, panel);
            button.Setup (character, forceAvailable);
        }

        private void SetAvailableCharacters (List<ObjectId> availableIds)
        {
            foreach (ObjectId id in availableIds)
                buttons[id].isAvailable = true;
        }
    }
}