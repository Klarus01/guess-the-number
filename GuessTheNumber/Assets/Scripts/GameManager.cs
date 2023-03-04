using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuView;
    [SerializeField]
    private GameObject gameplayView;
    [SerializeField]
    private GameObject chooseButton;
    [SerializeField]
    private GameObject lessButton;
    [SerializeField]
    private GameObject moreButton;

    [SerializeField]
    private TMP_InputField inputText;
    [SerializeField]
    private TextMeshProUGUI responseText;

    [SerializeField]
    private int minRange = 1;
    [SerializeField]
    private int maxRange = 100;
    [SerializeField]
    private int number;

    private int guesses = 0;
    private int ai;
    private int aiMax;
    private int aiMin;
    private bool numberCheck;


    public void StartGame()
    {
        aiMin = minRange;
        aiMax = maxRange;
        menuView.SetActive(false);
        gameplayView.SetActive(true);
        responseText.GetTextInfo("Gimme number " + minRange + " - " + maxRange);
        ai = Random.Range(minRange, maxRange + 1);
    }

    public void GetInput(string input)
    {
        int.TryParse(input, out number);

        if (number < minRange || number > maxRange)
        {
            return;
        }

        if (!numberCheck)
        {
            chooseButton.SetActive(false);
            lessButton.SetActive(true);
            moreButton.SetActive(true);
            numberCheck = true;
        }

        guesses++;

        responseText.GetTextInfo(ai.ToString());

        WinCondition();
    }

    public void Less()
    {
        aiMax = ai;

        guesses++;
        ai = Random.Range(aiMin, aiMax + 1);
        responseText.GetTextInfo(ai.ToString());
        WinCondition();
    }

    public void More()
    {
        aiMin = ai;

        guesses++;
        ai = Random.Range(aiMin, aiMax + 1);
        responseText.GetTextInfo(ai.ToString());
        WinCondition();
    }

    public void WinCondition()
    {
        if (ai == number)
        {
            responseText.GetTextInfo("Congratulation, " + ai + " is correct number. It took you " + guesses + " guesses");
            numberCheck = false;
            menuView.SetActive(true);
            lessButton.SetActive(false);
            moreButton.SetActive(false);
            chooseButton.SetActive(true);
        }
    }



}
