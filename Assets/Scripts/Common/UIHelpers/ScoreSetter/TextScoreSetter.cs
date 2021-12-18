using UnityEngine;
using UnityEngine.UI;

namespace Common.UIHelpers.ScoreSetter
{
    public class TextScoreSetter : BaseScoreSetter
    {
        [SerializeField] protected Text _text;

        protected override void UpdateText(string text) => 
            _text.text = text;
    }
}