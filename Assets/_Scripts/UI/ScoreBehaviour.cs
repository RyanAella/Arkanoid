using System;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class ScoreBehaviour : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;

        // public static float time;
        public static int Score;
        // private int highscore;

        // Start is called before the first frame update
        void Start()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();

            // set score value to be zero
            // time = 0;
            Score = 0;
            // highscore = 0;
        }

        // Update is called once per frame
        void Update()
        {
            string sTime = GameManager.Time.ToString("F2");
            // update text of Text element
            _textMeshPro.SetText("Time: {0} \nScore: {1} \nLife: {2}",
                Convert.ToSingle(sTime), Score, GameManager.CurrentPlayerLive);
        }
    }
}