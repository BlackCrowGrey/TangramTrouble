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
        bool[] dragging;

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

            dragging = new bool[7];
            for (int i = 0; i < dragging.Length; i++)
            {
                dragging[i] = false;
            }

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
            gui.BigTriangle1.PositionX = 200;
            gui.BigTriangle1.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 100;
            shapes.Add(gui.BigTriangle1);

            bigTriangleB = this.Content.Load<Texture2D>("bigTriangle2");
            gui.BigTriangle2 = new Shape(bigTriangleB, 150, GraphicsDevice.Viewport.Height - 75);
            gui.BigTriangle2.PositionX = 450;
            gui.BigTriangle2.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 50;
            shapes.Add(gui.BigTriangle2);

            mediumTriangle = this.Content.Load<Texture2D>("mediumTriangle");
            gui.MediumTriangle = new Shape(mediumTriangle, 250, GraphicsDevice.Viewport.Height - 75);
            gui.MediumTriangle.PositionX = 625;
            gui.MediumTriangle.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 100;
            shapes.Add(gui.MediumTriangle);

            smallTriangleA = this.Content.Load<Texture2D>("smallTriangle1");
            gui.SmallTriangle1 = new Shape(smallTriangleA, 350, GraphicsDevice.Viewport.Height - 75);
            gui.SmallTriangle1.PositionX = 825;
            gui.SmallTriangle1.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 100;
            shapes.Add(gui.SmallTriangle1);

            smallTriangleB = this.Content.Load<Texture2D>("smallTriangle2");
            gui.SmallTriangle2 = new Shape(smallTriangleB, 450, GraphicsDevice.Viewport.Height - 75);
            gui.SmallTriangle2.PositionX = 975;
            gui.SmallTriangle2.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 100;
            shapes.Add(gui.SmallTriangle2);

            square = this.Content.Load<Texture2D>("square");
            gui.Square = new Shape(square, 550, GraphicsDevice.Viewport.Height - 75);
            gui.Square.PositionX = 1125;
            gui.Square.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 100;
            shapes.Add(gui.Square);

            parallelogram = this.Content.Load<Texture2D>("parallelogram");
            gui.Parallelogram = new Shape(parallelogram, 650, GraphicsDevice.Viewport.Height - 75);
            gui.Parallelogram.PositionX = 1325;
            gui.Parallelogram.PositionY = gui.GD.GraphicsDevice.Viewport.Height - 100;
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

                    Rectangle[] rectangles = new Rectangle[7];
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        rectangles[i] = new Rectangle(shapes[i].PositionX - shapes[i].Width / 2, shapes[i].PositionY - shapes[i].Height / 2, shapes[i].Width, shapes[i].Height);
                    }

                    Rectangle mouseLoc = new Rectangle(mouse.Position.X, mouse.Position.Y, 1, 1);
                    for (int i = 0; i < rectangles.Length; i++)
                    {
                        if (rectangles[i].Intersects(mouseLoc)){
                            bool currentlyDragging = false;
                            int currentShape = -1;
                            for (int j = 0; j < rectangles.Length; j++)
                            {
                                if (dragging[j])
                                {
                                    currentShape = j;
                                    currentlyDragging = true;
                                }
                            }
                            if (currentlyDragging)
                            {
                                shapes[currentShape].Drag(mouse);
                                shapes[currentShape].Rotate(mouse, keyboard);
                            }
                            else
                            {
                                dragging[i] = true;
                            }
                        }
                    }
                    if(mouse.LeftButton != ButtonState.Pressed && !keyboard.IsKeyDown(Keys.Q) && !keyboard.IsKeyDown(Keys.E))
                    {
                        for (int i = 0; i < dragging.Length; i++)
                        {
                            dragging[i] = false;
                        }
                    }
                    
                    //gui.TestShape.Drag(mouse);

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
