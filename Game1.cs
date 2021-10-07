using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Names: Zawn Zachow, Dylan Mahala
 * Project: Tangram Trouble
 */
namespace TangramTrouble
{
    enum GameState
    {
        Menu,
        Options,
        GamePlay,
        Pause
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //team-made fields
        int score;
        int level;
        int levelShapes;
        int totalShapes;
        Texture2D background;
        Texture2D button;
        SpriteFont font;

        GameState gamestate;
        GameState prevGamestate;

        KeyboardState prevKB;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            switch (gamestate)
            {
                case GameState.Menu:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        prevGamestate = gamestate;
                        gamestate = GameState.GamePlay;
                    }
                    if (SingleKeyPress(Keys.O))
                    {
                        prevGamestate = gamestate;
                        gamestate = GameState.Options;
                    }
                    break;

                case GameState.Options:
                    if (prevGamestate == GameState.Menu && (SingleKeyPress(Keys.O) == true))
                    {
                        prevGamestate = gamestate;
                        gamestate = GameState.Menu;
                    }
                    if (prevGamestate == GameState.Pause && (SingleKeyPress(Keys.O) == true))
                    {
                        prevGamestate = gamestate;
                        gamestate = GameState.Pause;
                    }
                    break;

                case GameState.GamePlay:
                    if (SingleKeyPress(Keys.Space))
                    {
                        prevGamestate = gamestate;
                        gamestate = GameState.Pause;
                    }
                    break;

                case GameState.Pause:
                    if (SingleKeyPress(Keys.Space))
                    {
                        prevGamestate = gamestate;
                        gamestate = GameState.GamePlay;
                    }
                    if (SingleKeyPress(Keys.O))
                    {
                        prevGamestate = gamestate;
                        gamestate = GameState.Options;
                    }
                    if (SingleKeyPress(Keys.E))
                    {
                        prevGamestate = gamestate;
                        gamestate = GameState.Menu;
                    }
                    break;

            }
 
            prevKB = Keyboard.GetState();
            //Leave the prevKB declaration at the end of the method: it needs to be last. -Zawn

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            switch (gamestate)
            {
                case GameState.Menu:
                    //menu drawing
                    GraphicsDevice.Clear(Color.Tan);
                    break;

                case GameState.Options:
                    //options drawing
                    GraphicsDevice.Clear(Color.White);
                    break;

                case GameState.GamePlay:
                    //gameplay stuff
                    GraphicsDevice.Clear(Color.SaddleBrown);
                    break;

                case GameState.Pause:
                    //pause screen
                    GraphicsDevice.Clear(Color.BlanchedAlmond);
                    break;

            }

            _spriteBatch.End();

            base.Draw(gameTime);

        }

        //team-made methods

        public void NextLevel()
        {
            level++;
            totalShapes += levelShapes;
        }

        /// <summary>
        /// Checks for a single key press of a specified key.
        /// </summary>
        /// <param name="key"> The key being pressed. </param>
        /// <returns>True if the key was up in the last frame and down in the current. Otherwise false.</returns>
        public bool SingleKeyPress(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && prevKB.IsKeyUp(key);
        }
    }
}
