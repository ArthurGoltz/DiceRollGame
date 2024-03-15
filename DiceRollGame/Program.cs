
var diceGame = new DiceGame();

diceGame.StartGame();
var numberOfTriesLeft = diceGame.Play();
diceGame.Result(numberOfTriesLeft);



public class Dice
{
    public int Roll()
    {
        return new Random().Next(1, 6);
    }
}


class DiceGame
{
    private Dice _dice;
    private const int NumberOfTries = 3;
    public void StartGame()
    {
        _dice = new Dice();
    }

    public string GetGuess()
    {
        Console.WriteLine("Enter a number: ");
        return Console.ReadLine();
    }

    public int Play()
    {
        var diceRoll = _dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what number it shows in {NumberOfTries} tries: ");
        var triesLeft = NumberOfTries;
        while (triesLeft > 0)
        {
            var guess = GetGuess();

            var guessNumber = 0;

            if (!DiceGuessValidator.IsValidNumber(guess, out guessNumber))
                continue;

            if (DiceGuessValidator.IsRightGuess(guessNumber, diceRoll))
                break;

            --triesLeft;
        }
        return triesLeft;
    }

    public void Result(int numberOfTries)
    {
        if (numberOfTries > 0)
            Console.WriteLine("You Win");
        else
            Console.WriteLine("You Lose");
    }
}

static class DiceGuessValidator
{
    public static bool IsValidNumber(string guess, out int number)
    {
        var isValidNumber = int.TryParse(guess, out number);
        if (!isValidNumber)
        {
            Console.WriteLine("Incorrect Input");
            return false;
        }
        return true;
    }

    public static bool IsRightGuess(int guess, int roll)
    {
        return guess == roll;
    }
}

