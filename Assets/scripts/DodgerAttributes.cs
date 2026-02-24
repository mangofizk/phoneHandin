using UnityEngine;

public class DodgerAttributes
{
    private int currentHealth;
    private int maximumHealth;
    private int currentScore;
    

    public DodgerAttributes(int currentHealth, int maximumHealth, int currentscore)
    {
        this.currentHealth = currentHealth;
        this.maximumHealth = maximumHealth;
        this.currentScore = currentscore;
    }

    public int getcurrenthealth()
    {
        return currentHealth;
    }
    public int getmaximumHealth()
    {
        return maximumHealth;
    }
    public int getcurrentScore()
    {
        return currentScore;
    }

    public void setcurrenthealth(int value)
    {
        currentHealth = value;
    }

    public void setcururrentscore(int value)
    {
        currentScore = value;
    }
}
