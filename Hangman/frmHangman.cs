using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Hangman
{
    public partial class frmHangman : Form
    {
        private Hangman hangman;
        private Label[] guessBoxesArray; // An array containing all guessBoxes 1 - 6.
        private Button[] letterButtonArray; // An array containing all 26 letter buttons.
        private Panel[] panelsArray; // An array containing all the panels in the form.
        private Color wrongColor; // The color for incorrectness.
        private Color rightColor; // The color for correctness.
        private bool soundMuted; // True if sound is muted, false otherwise.
        SoundPlayer player; // Create to play audio cue.


        // Loads everything up properly.
        private void frmHangman_Load(object sender, EventArgs e)
        {
            // This for loop adds the colored boxes representing the number of guesses remaining.
            for (int i = 0; i < 6; i++)
            {
                int startingX = 13; // Represents the X coordinate of the left most guessBox.
                int startingY = 41; // Represents the Y coordinate of the left most guessBox.
                Label lblGuessBox = new Label();
                lblGuessBox.BackColor = rightColor;
                lblGuessBox.AutoSize = true;
                lblGuessBox.BorderStyle = BorderStyle.FixedSingle;
                lblGuessBox.Font = new Font("Microsoft Sans Serif", 20F);
                lblGuessBox.Margin = new Padding(2, 0, 2, 0);
                lblGuessBox.Size = new Size(37, 33);
                lblGuessBox.Text = "   ";
                lblGuessBox.Location = new Point(startingX + 41 * i, startingY);
                lblGuessBox.Name = "guessBox" + i;


                this.guessBoxesArray[i] = lblGuessBox; // Add to array.

                this.pnlGame.Controls.Add(lblGuessBox);

                SaveController.load(); // Load the save.
            }

            // This for loop adds all the buttons for the letters without having to manually do so.
            for (int i = 0; i < 26; i++)
            {
                int startingX = 55; // The X coordinate of the top left most button.
                int startingY = 125; // The Y coordinate of the top left most button.

                Button letterButton = new Button();
                letterButton.Size = new Size(50, 50);
                letterButton.TabStop = false;
                letterButton.UseVisualStyleBackColor = false;
                letterButton.Text = "" + (char)('A' + i);
                letterButton.Click += new System.EventHandler(this.btnLetter_Click);

                if (i >= 24) // If the letters are the last two, position them in the center bottom row.
                {
                    letterButton.Location = new Point(startingX + (i - 24 + 3) * 61, startingY + (i / 8 * 61));
                }
                else // Otherwise, place them normally.
                {
                    letterButton.Location = new Point(startingX + (i % 8) * 61, startingY + (i / 8 * 61)); // Properly places the button depending on what letter it is.
                }


                this.letterButtonArray[i] = letterButton; // Add to array.

                this.pnlGame.Controls.Add(letterButton);
            }

            // Add panels to array.
            this.panelsArray[0] = this.pnlMenu;
            this.panelsArray[1] = this.pnlGame;

            // Add keypress event handler to pnlGame.
            (pnlGame as Control).KeyPress += new KeyPressEventHandler(pnlGame_KeyPress); // Add keypress event handler to pnlGame.
        }

        // Close event handler. Saves the game first before closing.
        private void frmHangman_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveController.save();
        }

        public frmHangman()
        {
            InitializeComponent();

            this.hangman = new Hangman(); // Create the hangman object used for this game.
            this.guessBoxesArray = new Label[6]; // Create the array of 6 guessBoxes.
            this.letterButtonArray = new Button[26]; // Create the array of 26 letter buttons.
            this.panelsArray = new Panel[2]; // Create the array of 2 panels.
            this.wrongColor = Color.Red; // Initialize color for wrongness.
            this.rightColor = Color.Blue; // Initialize color for correctness.
            this.soundMuted = false; // Sound is on by default.
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(this, "Are you sure you would like to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Close();
            }
        }

        // The event handler for all letter button clicks. Processes a guess and then checks game status.
        private void btnLetter_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            btnSender.Hide();

            player = new SoundPlayer("..\\..\\lib\\ButtonClick.mp4");
            playSound();

            if (!this.hangman.processGuess(btnSender.Text)) // If the guess is wrong, update guess boxes and select right file.
            {
                updateGuessBoxes();
                player = new SoundPlayer("..\\..\\lib\\Incorrect.mp4");
            } else // If the guess is right, update the word so far.
            {
                updateWordSoFar();
                player = new SoundPlayer("..\\..\\lib\\Correct.mp4");
            }

            playSound();

            pnlGame.Focus(); // Bring focus back to pnlGame so pressing Esc still opens up menu.

            checkGameStatus(); // Check if that guess wins or loses a game.
        }

        // Updates the guess boxes to accurately represent the remaining number of wrong guesses.
        private void updateGuessBoxes()
        {
            for (int i = 0; i < this.hangman.getWrongCount(); i++)
            {
                this.guessBoxesArray[5 - i].BackColor = wrongColor;
            }
        }

        // Updates the word so far to accurately represent the word so far.
        private void updateWordSoFar()
        {
            StringBuilder wordSoFar = new StringBuilder(this.hangman.getWordSoFar().Length * 2);
            for (int i = 0; i < this.hangman.getWordSoFar().Length; i++)
            {
                wordSoFar.Append(this.hangman.getWordSoFar()[i] + " ");
            }

            this.lblWordSoFar.Text = wordSoFar.ToString();
        }

        // Checks the status of the game and will end the game if need be.
        private void checkGameStatus()
        {
            int gameState = this.hangman.getGameState();

            if (gameState == 0 || gameState == 1)
            {
                endGame();
            }
        }

        // Ends the game with either a win or a loss.
        private void endGame()
        {
            recordGame();

            if (this.hangman.getGameState() == 1) // Choose right audio file depending on gamestate.
            {
                player = new SoundPlayer("..\\..\\lib\\Victory.mp4");
            } else
            {
                player = new SoundPlayer("..\\..\\lib\\GameOver.mp4");
            }

            playSound();

            frmGameEnd endGameScreen = new frmGameEnd(this.hangman.getGameState(), this.hangman.getChosenWord());

            if (DialogResult.Cancel == endGameScreen.ShowDialog())
            {
                goToPanel("pnlMenu");
            } else
            {
                startGame();
            }
        }

        // Saves the game result into the save controller.
        private void recordGame()
        {
            SaveController.saveGame(this.hangman.getGameState(), hangman.getDifficulty());
        }

        // Starts a game of Hangman.
        private void startGame()
        {
            this.hangman.startNewGame();
            updateWordSoFar();

            for (int i = 0; i < this.guessBoxesArray.Length; i++) // Change guess boxes back to green.
            {
                this.guessBoxesArray[i].BackColor = rightColor;
            }

            for (int i = 0; i < this.letterButtonArray.Length; i++) // Show all letter buttons again.
            {
                letterButtonArray[i].Show();
            }
        }

        // Go to the given panel.
        private void goToPanel(string panelName)
        {
            foreach (Panel pnl in this.panelsArray)
            {
                if (pnl.Name == panelName)
                {
                    pnl.BringToFront();
                    pnl.Focus(); // Bring that panel into focus.
                } else
                {
                    pnl.SendToBack();
                }
            }
        }

        // The event handler for if btnStartGame is clicked. Starts the game and goes to the game panel.
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            startGame();
            goToPanel("pnlGame");
        }

        // The event handler for it btnMenu is clicked. Opens pop-up menu.
        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmPopupMenu frmPopupMenu = new frmPopupMenu();

            DialogResult menuResult = frmPopupMenu.ShowDialog();

            if (DialogResult.Abort == menuResult)
            {
                // Set to loss, and then record it.
                this.hangman.setGameState(0);
                recordGame();

                goToPanel("pnlMenu");
            } else if (DialogResult.Retry == menuResult)
            {
                this.hangman.setGameState(0); // Set gamestate to a loss and end the game.
                endGame();
            }
        }

        // Handles key events on the form. Will be used so that pressing esc while in pnlGame opens the pop-up menu.
        private void pnlGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) // If the keypress is escape.
            {
                btnMenu_Click(this.btnMenu, EventArgs.Empty); // Act as if btnMenu was clicked.
            }
        }

        // Get the soundMuted value.
        public bool isMuted()
        {
            return this.soundMuted;
        }

        // Event handler for options button.
        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmOptions options = new frmOptions(this);
            options.ShowDialog();
        }

        // Gets the hangman model in the form.
        public Hangman getHangman()
        {
            return this.hangman;
        }

        // Sets the sound to muted or no.
        public void setSound(bool hasSound)
        {
            this.soundMuted = !hasSound;
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            frmRecords recordsWindow = new frmRecords();
            recordsWindow.ShowDialog();
        }

        // Plays the sound that is currently set.
        private void playSound()
        {
            if (!this.soundMuted) // Only plays sound if it is not muted.
            {
                player.Play();
            }
        }
    }

    // The model for the program. Contains hangman game mechanic and logic.
    public class Hangman
    {
        private string[] wordList; // The list of words being chosen from.
        public string chosenWord; // The chosen hidden word.
        private StringBuilder wordSoFar; // The word the user has guessed so far.
        private int wrongGuesses; // The amount of wrong guesses by the user.
        private const int MAX_GUESSES = 6; // The allotted max number of wrong guesses.

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
        public void startNewGame()
        {
            this.wordList = chooseList();
            this.chosenWord = chooseWord();
            this.wordSoFar = new StringBuilder(createBlanks());
            this.wrongGuesses = 0;
            this.gamestate = GameState.ONGOING;
        }

        // Picks the list of words to choose from based on the difficulty level.
        private string[] chooseList()
        {
            switch (this.difficulty) // Depending on the difficulty level, extract the words from the proper text file.
            {
                case Difficulty.EASY:
                    return File.ReadAllLines("..\\..\\lib\\EasyWords.txt");
                case Difficulty.MEDIUM:
                    return File.ReadAllLines("..\\..\\lib\\MediumWords.txt");
                case Difficulty.HARD:
                    return File.ReadAllLines("..\\..\\lib\\HardWords.txt");
                default: // Should never get here.
                    string[] unused = { };
                    return unused;
            }
        }

        // Picks a random word from the list of words.
        private string chooseWord()
        {
            Random numGen = new System.Random();
            return this.wordList[numGen.Next(this.wordList.Length - 1)]; // Randomly generate an index and pick the word at that index in the wordList.
        }

        // Creates the representation of the word with blanks.
        private string createBlanks()
        {
            String dashes = "";

            foreach (char c in this.chosenWord) // For each character in the chosenWord, add an _ to the wordSoFar.
            {
                dashes += "_";
            }

            return dashes;
        }

        // The overriding processGuess method for public use. Accepts a string instead of a character.
        public bool processGuess(String guess)
        {
            return processGuess(guess.ToLower()[0]);
        }

        // Processes a guess and checks if it is correct or not, if it is, return true, otherwise false.
        private bool processGuess(char guess)
        {
            bool notFound = true;

            for (int i = 0; i < this.chosenWord.Length; i++) // Checks to see if the guessed letter is found in the word and then updates the wordSoFar.
            {
                if (this.chosenWord[i].Equals(guess))
                {
                    this.wordSoFar[i] = guess;
                    notFound = false;
                }
            }

            if (notFound) // If the guessed letter was not found, increase wrong guesses by 1.
            {
                this.wrongGuesses++;
            }

            if (this.chosenWord.Equals(this.wordSoFar.ToString())) // If the word so far matches the chosen word, set gamestate to a win.
            {
                this.gamestate = GameState.WIN;
            }
            else if (this.wrongGuesses == Hangman.MAX_GUESSES) // If the amount of wrong guesses equals the max permitted guesses, set gamestate to a loss.
            {
                this.gamestate = GameState.LOSS;
            }

            return !notFound; // Return true if the guess is found, false otherwise.
        }

        // Gets gamestate, returns 0 if losing, 1 if winning, and 2 if ongoing.
        public int getGameState()
        {
            if (gamestate == GameState.LOSS)
            {
                return 0;
            }
            else if (gamestate == GameState.WIN)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        // Returns the amount of wrong guesses so far.
        public int getWrongCount()
        {
            return this.wrongGuesses;
        }

        // Gets the chosen word.
        public string getChosenWord()
        {
            return this.chosenWord;
        }
        // Gets the word so far.
        public string getWordSoFar()
        {
            return this.wordSoFar.ToString();
        }

        // Sets the gamestate.
        public void setGameState(int state)
        {
            switch (state)
            {
                case 0:
                    this.gamestate = GameState.LOSS;
                    break;
                case 1:
                    this.gamestate = GameState.WIN;
                    break;
                default:
                    this.gamestate = GameState.ONGOING;
                    break;
            }
        }

        // Gets the difficulty.
        public int getDifficulty()
        {
            switch (this.difficulty)
            {
                case Difficulty.EASY:
                    return 0;
                case Difficulty.MEDIUM:
                    return 1;
                case Difficulty.HARD:
                    return 2;
                default: // Should never get here.
                    return 1;
            }
        }

        // Sets the difficulty.
        public void setDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 0:
                    this.difficulty = Difficulty.EASY;
                    break;
                case 1:
                    this.difficulty = Difficulty.MEDIUM;
                    break;
                case 2:
                    this.difficulty = Difficulty.HARD;
                    break;
                default:
                    break;
            }
        }
    }


    // The save controller for the program.
    public static class SaveController
    {
        // Array representing wins and losses with difficulty. Arranged like [EasyWins, EasyLosses, MedWins, MedLosses, HardWins, HardLosses]
        private static int[] winLossesArray = new int[6];

        // Saves the winLossesArray into the save.txt file.
        public static void save()
        {
            string[] saveArray = new string[6];
            for (int i = 0; i < 6; i++)
            {
                saveArray[i] = SaveController.winLossesArray[i].ToString();
            }
            File.WriteAllLines("..\\..\\lib\\save.txt", saveArray);
        }

        // Loads the save file into the winLossesArray.
        public static void load()
        {
            string[] saveArray = File.ReadAllLines("..\\..\\lib\\save.txt");
            for (int i = 0; i < 6; i++)
            {
                SaveController.winLossesArray[i] = Int32.Parse(saveArray[i]);
            }
        }

        // Adds a win/loss with its difficulty into the winLossesArray. 1 is win, 0 is loss. 0, 1, 2, is easy, medium, and hard, respectively.
        public static void saveGame(int state, int difficulty)
        {
            SaveController.winLossesArray[difficulty * 2 + Math.Abs(state - 1)] += 1;
        }

        // Clears all save information.
        public static void resetSave()
        {
            for (int i = 0; i < 6; i++)
            {
                SaveController.winLossesArray[i] = 0;
            }

            save();
        }

        // Returns the winLossesArray.
        public static int[] getSave()
        {
            return SaveController.winLossesArray;
        }
    }
}
