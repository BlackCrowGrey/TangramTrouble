using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Names: Zawn Zachow, Dylan Mahala, Beckett Raver, Andrew Tark
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
        bool holdingShape;

        Texture2D tangramOutline;
        Texture2D bigTriangleA;
        Texture2D bigTriangleB;
        Texture2D mediumTriangle;
        Texture2D smallTriangleA;
        Texture2D smallTriangleB;
        Texture2D square;
        Texture2D parallelogram;
        Texture2D button;
        SpriteFont font;
        Gui gui;
        List<Shape> shapes = new List<Shape>();

        //Shape testShape;
        Texture2D gummy;
        MouseState mouse;
        KeyboardState keyboard;

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
            gui = new Gui();
            gui.GD = _graphics;

            //Enlarges the window size
            _graphics.PreferredBackBufferWidth = 1500;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gui.SB = _spriteBatch;
            // TODO: use this.Content to load your game content here
            tangramOutline = this.Content.Load<Texture2D>("tangram");
            gui.Outline = tangramOutline;

            bigTriangleA = this.Content.Load<Texture2D>("bigTriangle1");
            gui.BigTriangle1 = new Shape(bigTriangleA, 50, GraphicsDevice.Viewport.Height - 75);
            gui.BigTriangle1.PositionX = 50;
            gui.BigTriangle1.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 175;
            shapes.Add(gui.BigTriangle1);

            bigTriangleB = this.Content.Load<Texture2D>("bigTriangle2");
            gui.BigTriangle2 = new Shape(bigTriangleB, 150, GraphicsDevice.Viewport.Height - 75);
            gui.BigTriangle2.PositionX = 375;
            gui.BigTriangle2.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 175;
            shapes.Add(gui.BigTriangle2);

            mediumTriangle = this.Content.Load<Texture2D>("mediumTriangle");
            gui.MediumTriangle = new Shape(mediumTriangle, 250, GraphicsDevice.Viewport.Height - 75);
            gui.MediumTriangle.PositionX = 550;
            gui.MediumTriangle.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 175;
            shapes.Add(gui.MediumTriangle);

            smallTriangleA = this.Content.Load<Texture2D>("smallTriangle1");
            gui.SmallTriangle1 = new Shape(smallTriangleA, 350, GraphicsDevice.Viewport.Height - 75);
            gui.SmallTriangle1.PositionX = 750;
            gui.SmallTriangle1.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 125;
            shapes.Add(gui.SmallTriangle1);

            smallTriangleB = this.Content.Load<Texture2D>("smallTriangle2");
            gui.SmallTriangle2 = new Shape(smallTriangleB, 450, GraphicsDevice.Viewport.Height - 75);
            gui.SmallTriangle2.PositionX = 875;
            gui.SmallTriangle2.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 175;
            shapes.Add(gui.BigTriangle2);

            square = this.Content.Load<Texture2D>("square");
            gui.Square = new Shape(square, 550, GraphicsDevice.Viewport.Height - 75);
            gui.Square.PositionX = 1050;
            gui.Square.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 175;
            shapes.Add(gui.Square);

            parallelogram = this.Content.Load<Texture2D>("parallelogram");
            gui.Parallelogram = new Shape(parallelogram, 650, GraphicsDevice.Viewport.Height - 75);
            gui.Parallelogram.PositionX = 1350;
            gui.Parallelogram.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 125;
            shapes.Add(gui.Parallelogram);

            button = this.Content.Load<Texture2D>("blankButton");
            gui.Button = button;

            font = this.Content.Load<SpriteFont>("SpriteFont1");
            gui.Font = font;

            //gummy = this.Content.Load<Texture2D>("greenGummy");
            //gui.TestShape = new Shape(gummy, 10, 10);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();

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

                    for (int i = 0; i < shapes.Count - 1; i++)
                    {
                        Rectangle shape1 = new Rectangle(shapes[i].PositionX - shapes[i].Width / 2, shapes[i].PositionY - shapes[i].Height / 2, shapes[i].Width, shapes[i].Height);
                        Rectangle shape2 = new Rectangle(shapes[i + 1].PositionX - shapes[i + 1].Width / 2, shapes[i + 1].PositionY - shapes[i + 1].Height / 2, shapes[i + 1].Width, shapes[i + 1].Height);
                        if (!shape1.Intersects(shape2))
                        {
                            shapes[i].Drag(mouse);
                            shapes[i].Rotate(mouse, keyboard);
                        }
                    }

                    //gui.TestShape.Drag(mouse);
                    //gui.BigTriangle1.Drag(mouse);
                    //gui.BigTriangle2.Drag(mouse);
                    //gui.MediumTriangle.Drag(mouse);
                    //gui.SmallTriangle1.Drag(mouse);
                    //gui.SmallTriangle2.Drag(mouse);
                    //gui.Square.Drag(mouse);
                    //gui.Parallelogram.Drag(mouse);
                    //gui.BigTriangle1.Rotate(mouse, keyboard);
                    //gui.BigTriangle2.Rotate(mouse, keyboard);
                    //gui.MediumTriangle.Rotate(mouse, keyboard);
                    //gui.SmallTriangle1.Rotate(mouse, keyboard);
                    //gui.SmallTriangle2.Rotate(mouse, keyboard);
                    //gui.Square.Rotate(mouse, keyboard);
                    //gui.Parallelogram.Rotate(mouse, keyboard);
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
            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            switch (gamestate)
            {
                case GameState.Menu:
                    //menu drawing
                    gui.DrawMenu();
                    break;

                case GameState.Options:
                    //options drawing
                    gui.DrawOptions();
                    break;

                case GameState.GamePlay:
                    //gameplay stuff
                    gui.DrawGamePlay();
                    break;

                case GameState.Pause:
                    //pause screen
                    gui.DrawPause();
                    break;

            }

            _spriteBatch.End();

            base.Draw(gameTime);

        }

        //team-made methods

        /// <summary>
        /// Moves the player to the next level of the game.
        /// </summary>
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
