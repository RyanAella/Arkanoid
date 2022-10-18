using System;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class VictoryBehaviour : MonoBehaviour
    {
        private TextMeshProUGUI victoryText;
    
        // Start is called before the first frame update
        void Start()
        {
            victoryText = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            var time = GameManager.time;
            var vTime = time.ToString("F2");
            victoryText.SetText("Score: {0} \nTime: {1} \nYou lost", ScoreBehaviour.score, Convert.ToSingle(vTime));
        }
    }
}
