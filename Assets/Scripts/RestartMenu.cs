using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] private string[] facts;

    [SerializeField] private TMP_Text factText;

    private void Awake()
    {
        factText.text = facts[Random.Range(0,facts.Length-1)];
    }

    public void Continue()
    {
        SceneManager.LoadScene("SubmarineTest");
    }
}