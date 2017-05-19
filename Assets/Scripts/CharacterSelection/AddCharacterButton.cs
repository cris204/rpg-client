using Characters;
using UnityEngine;
using UnityEngine.UI;

namespace CharacterSelection
{
	[RequireComponent (typeof (Button))]
	public class AddCharacterButton : MonoBehaviour 
	{
		public bool isAvailable;
		private Button button;
		private CharacterData character;

		private void Awake ()
		{
			button = GetComponent<Button> ();
			button.onClick.AddListener (OnClick);
		}

		public void Setup (CharacterData character, bool isAvailable = false)
		{
			this.character = character;
			this.isAvailable = isAvailable;
			button.image.sprite = character.portrait;
		}

		private void OnClick () 
		{
			TeamManager.Instance.AddCharacter (character);
		}
	}
}