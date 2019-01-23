using System;
using System.IO;

public class Hangman
{
    private String[] wordList;
    private String chosenWord;
    private String wordSoFar;
    private int wrongGuesses;
    private const int MAX_GUESSES = 6;
    private enum Difficulty { EASY, MEDIUM, HARD };
    private Difficulty difficulty;
    private enum GameState { ONGOING, WIN, LOSS };
    private GameState gamestate;

	public Hangman()
	{
        this.difficulty = Difficulty.MEDIUM;
        startNewGame();
	}

    // Starts a new game.
    private void startNewGame()
    {
        this.wordList = chooseList();
        this.chosenWord = chooseWord();
        this.wordSoFar = createBlanks();
        this.wrongGuesses = 0;
        this.gamestate = GameState.ONGOING;
    }

    // Picks the list of words to choose from based on the difficulty level.
    private String[] chooseList()
    {
        switch (this.difficultyLevel) // Depending on the difficulty level, extract the words from the proper text file.
        {
            case Difficulty.EASY:
                return File.ReadAllLines("lib\\EasyWords.txt");
            case Difficulty.MEDIUM:
                return File.ReadAllLines("lib\\MediumWords.txt");
            case Difficulty.HARD:
                return File.ReadAllLines("lib\\HardWords.txt");
            default: // Should never get here.
                return String[0];
        } 
    }

    // Picks a random word from the list of words.
    private String chooseWord()
    {
        Random numGen = new System.Random();
        return this.wordList[numGen.Next(this.wordList.Length - 1)]; // Randomly generate an index and pick the word at that index in the wordList.
    }

    // Creates the representation of the word with blanks.
    private String createBlanks()
    {
        String dashes;

        foreach (char c in this.chosenWord) // For each character in the chosenWord, add an _ to the wordSoFar.
        {
            dashes += "_";
        }

        return dashes;
    }

    // The overriding processGuess method for public use. Accepts a string instead of a character.
    public bool processGuess(String guess)
    {
        return processGuess(guess[0]);
    }

    // Processes a guess and checks if it is correct or not, if it is, return true, otherwise false.
    private bool processGuess(char guess)
    {
        bool notFound = true;

        for (int i = 0; i < this.chosenWord.Length - 1; i++) // Checks to see if the guessed letter is found in the word and then updates the wordSoFar.
        {
            if (this.chosenWord[i] == guess)
            {
                this.wordSoFar[i] = guess;
                notFound = false;
            }
        }

        if (notFound) // If the guessed letter was not found, increase wrong guesses by 1.
        {
            this.wrongGuesses++;
        }
        
        if (this.chosenWord.Equals(this.wordSoFar)) // If the word so far matches the chosen word, set gamestate to a win.
        {
            this.gamestate = GameState.WIN;
        } else if (this.wrongGuesses == Hangman.MAX_GUESSES) // If the amount of wrong guesses equals the max permitted guesses, set gamestate to a loss.
        {
            this.gamestate = GameState.LOSS;
        }

        return !notFound; // Return true if the guess is found, false otherwise.
    }

    // Checks gamestate, returns 0 if losing, 1 if winning, and 2 if ongoing.
    public int checkGameState()
    {
        if (gamestate == GameState.LOSS)
        {
            return 0;
        } else if (gamestate == GameState.WIN)
        {
            return 1;
        } else
        {
            return 2;
        }
    }
}
