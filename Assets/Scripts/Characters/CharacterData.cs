using System;
using UnityEngine;
using UnityRest;

namespace Characters
{
	[Serializable]
	public class CharacterData
	{
		public string name;
		public ObjectId id;
		public SelectableCharacter prefab;
		public Sprite portrait;
	}
}