using System;
using Characters;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CharacterSelection
{
    public class SelectableCharacter : MonoBehaviour, IPointerClickHandler
    {
        public CharacterData character;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log (gameObject.name);
        }
    }
}