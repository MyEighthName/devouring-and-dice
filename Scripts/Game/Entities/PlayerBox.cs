using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBox : MonoBehaviour
{
    public Hider UICanvas;
    public Hider DeathScreenCanvas;

    public GameObject viewPoint;
    public Dice dice;
    public Image[] powerUpShowcase;

    public GameObject playerPrefab;
    public float splitTime;

    public int totalSize => GetChildren().Sum(e => e.GetComponent<Entity>().size);
    public float totalRTSize => Resource.rtSizeMultiplier * Mathf.Sqrt(totalSize);
    public int count => GetChildren().Count();
    public int puCount => powerUps.Count();

    private Color standartPowerUpsShowcaseColor;
    private List<PowerUp> powerUps = new List<PowerUp>();

    public IEnumerable<Transform> GetChildren()
    {
        foreach (Transform child in transform)
        {
            if (child != viewPoint.transform)
                yield return child;
        }
    }

    public Transform First()
    {
        if (count == 0)
            return null;
        return GetChildren().First();
    }

    public void UnitePowerUps()
    {
        foreach (var child in GetChildren())
        {
            var newPU = new List<PowerUp>();
            foreach (var pu in powerUps)
                newPU.Add(new PowerUp(pu));
            child.GetComponent<Entity>().powerUps = newPU;
        }
    }

    public void AddPowerUp(PowerUp pu)
    {
        powerUps.Add(pu);
        UnitePowerUps();
    }

    private int diceValue;
    private int timesDiceAsked;

    private bool diceFlag;
    public bool isDiceRolled => diceFlag && timesDiceAsked < count;

    public void RollDice()
    {
        if (!isDiceRolled)
        {
            dice.Roll();
            diceValue = dice.GetValue();
            diceFlag = true;
            dice.button.transform.localScale = Vector3.zero;
        }
    }

    public int GetDiceValue()
    {
        if (!isDiceRolled)
            return 0;
        timesDiceAsked++;
        if (!isDiceRolled)
        {
            dice.button.SetActive(true);
            timesDiceAsked = 0;
            diceFlag = false;
        }
        return diceValue;
    }

    private void Start()
    {
        standartPowerUpsShowcaseColor = powerUpShowcase[0].color;
    }

    private void FixedUpdate()
    {
        if (isDiceRolled && !dice.isInAnimationPhase)
            dice.button.SetActive(false);

        splitTime -= Time.fixedDeltaTime;
        if (count == 0)
            CallDeathScreen();
        UpdatePowerUpShowcase();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        var nextPosition = Vector3.zero;
        foreach (var child in GetChildren())
            nextPosition += child.position;
        nextPosition /= count;

        viewPoint.transform.position = nextPosition;
    }

    private void UpdatePowerUpShowcase()
    {
        foreach (var powerUp in powerUps)
            powerUp.LowerDuration(Time.fixedDeltaTime);
        powerUps = powerUps.Where(pu => pu.isActive).ToList();

        for (var i = 0; i < powerUpShowcase.Length; i++)
        {
            if (powerUpShowcase[i] != null)
            {
                if (i < powerUps.Count)
                {
                    powerUpShowcase[i].sprite = powerUps[i].sprite;
                    powerUpShowcase[i].color = powerUps[i].color;
                    powerUpShowcase[i].gameObject.GetComponent<ProgressBar>().progress = 1 - powerUps[i].timeFraction;
                }
                else
                {
                    powerUpShowcase[i].sprite = null;
                    powerUpShowcase[i].color = standartPowerUpsShowcaseColor;
                    powerUpShowcase[i].gameObject.GetComponent<ProgressBar>().progress = 0;
                }
            }
        }
    }

    public void CallDeathScreen()
    {
        UICanvas.SetInactive();
        DeathScreenCanvas.SetActive();
    }
}
