using System;
using UnityEngine;

namespace Dialog
{
    [Serializable]
    public class Phrase
    {
        [SerializeField] private string text;
        [SerializeField] private float duration;

        public string Text => text;
        public float Duration => duration;
    }
}