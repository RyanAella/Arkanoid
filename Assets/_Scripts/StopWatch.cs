using TMPro;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    public float timeStart;
    public TextMeshProUGUI textbox;
    
    // Start is called before the first frame update
    void Awake()
    {
        textbox.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        textbox.text = timeStart.ToString("F2");
    }
}
