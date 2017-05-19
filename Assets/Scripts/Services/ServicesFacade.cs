using System;
using System.Collections.Generic;
using CharacterSelection;
using UnityEngine;
using UnityRest;

namespace Services
{
    public class ServicesFacade: MonoBehaviour
    {
        public static ServicesFacade Instance
        {
            get; private set;
        }

        [SerializeField]
        private string userId;

        private void Awake ()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy (gameObject);
        }

        public void FetchGold(Action<int> onSuccess)
        {
            // TODO: Call get gold service
            onSuccess (500);
        }

        public void Login (string username, Action onSuccess)
        {
            // TODO: Call login service using username, if successful invoke callback and set userId
            userId = "1";
            onSuccess ();
        }

        public void FetchTeam (Action<Team> onSuccess)
        {
            // TODO: Call team service using the userId to retrieve the current characters in his team
            // if none is available create a new one empty.
            onSuccess (new Team ());
        }

        public void SaveTeam (Team team, Action onSuccess)
        {
            // TODO: Call save team service using ids
            onSuccess ();
        }

        public void GetAvailableCharacters (Action<List<ObjectId>> onSuccess)
        {
            // TODO: Fetch unlocked characters service that returns the list with all available ids.
            onSuccess (new List<ObjectId> ());
        }

        public void PurchaseCharacter (ObjectId id, Action onSuccess)
        {
            // TODO: Call purchasing service.
            onSuccess ();
        }
    }
}