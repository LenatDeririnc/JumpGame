using TMPro;
using UnityEngine;

namespace Common.UIHelpers.ScoreSetter
{
    public class TMPScoreSetter : BaseScoreSetter
    {
        [SerializeField] protected TMP_Text _text;

        protected override void UpdateText(string text) => 
            _text.text = text;
    }
}
