using Characters;
using Services;
using UnityEngine;
using Utils;

namespace CharacterSelection
{
	public class TeamManager : MonoBehaviour
	{
		[SerializeField]
		private int size;
		[SerializeField]
		private GameObjectHorizontalLayout layout;
		private Team team;

		public static TeamManager Instance
		{
			get; private set;
		}

		private void Awake ()
		{
			Instance = this;
		}

		private void Start () 
		{
			ServicesFacade.Instance.FetchTeam (SetCurrentTeam);
		}

		public void AddCharacter (CharacterData character)
		{
			if (team == null || team.characters.Count == size) return;
			team.AddCharacter (character);
			AddToLayout (character);
		}

        public void RemoveCharacter (CharacterData character)
		{
			if (team == null || team.characters.Count == 0) return;
			team.RemoveCharacter (character);
		}

		public void SaveTeam ()
		{
			ServicesFacade.Instance.SaveTeam (team, () => Debug.Log ("Saved"));
		}

		private void SetCurrentTeam (Team team)
		{
			this.team = team;
		}

		private void AddToLayout(CharacterData character)
        {
            SelectableCharacter selectable = Instantiate<SelectableCharacter> (character.prefab, transform);
			selectable.character = character;
			layout.Add (selectable.gameObject);
        }
	}
}