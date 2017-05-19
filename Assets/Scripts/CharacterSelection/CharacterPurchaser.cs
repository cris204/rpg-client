using System.Collections.Generic;
using Characters;
using Players;
using Services;
using UnityEngine;
using UnityEngine.UI;
using UnityRest;

namespace CharacterSelection
{
    public class CharacterPurchaser: MonoBehaviour
    {
        [SerializeField]
        private Text costLabel;
        private CharacterData character;

        public static CharacterPurchaser Instance
        {
            get; private set;
        }

        private void Awake ()
        {
            Instance = this;
            Hide ();
        }

        public void StartPurchase (CharacterData character)
        {
            this.character = character;
            gameObject.SetActive (true);
        }

        public void Confirm ()
        {
            if (Player.Instance.Gold >= character.cost)
                ServicesFacade.Instance.PurchaseCharacter (character.id, OnPurchaseCompleted);
            Hide ();
        }

        public void Hide ()
        {
            gameObject.SetActive (false);
        }

        private void OnPurchaseCompleted ()
        {
            Player.Instance.UseGold (character.cost);
            AvailableCharactersPanel.Instance.SetAvailableCharacters (new List<ObjectId> () {character.id});
        }
    }
}