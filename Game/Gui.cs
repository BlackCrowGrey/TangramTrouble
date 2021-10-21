using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Names: Zawn Zachow, Dylan Mahala, Beckett Raver
 * Project: Tangram Trouble
 */
namespace TangramTrouble
{
	/// <summary>
	/// Handles drawing the different game screens
	/// </summary>
	class Gui
	{
		//Fields to hold needed data to draw
		private SpriteBatch sb;
		private GraphicsDeviceManager gd;

		private Texture2D outline;
		private Shape bigTriangle1;
		private Shape bigTriangle2;
		private Shape mediumTriangle;
		private Shape smallTriangle1;
		private Shape smallTriangle2;
		private Shape square;
		private Shape parallelogram;
		private Texture2D button;
		private SpriteFont font;

		/// <summary>
		/// SpriteBatch to draw
		/// </summary>
		public SpriteBatch SB
        {
			get { return sb; }
			set { sb = value; }
        }

		/// <summary>
		/// GraphicsDeviceManager to manage the screen
		/// </summary>
		public GraphicsDeviceManager GD
		{
			get { return gd; }
			set { gd = value; }
		}

		/// <summary>
		/// Texture2D that holds the tangram outline image
		/// </summary>
		public Texture2D Outline
		{
			get { return outline; }
			set { outline = value; }
		}

		/// <summary>
		/// Texture2D that holds the first big triangle image
		/// </summary>
		public Shape BigTriangle1
		{
			get { return bigTriangle1; }
			set { bigTriangle1 = value; }
		}

		/// <summary>
		/// Texture2D that holds the second big triangle image
		/// </summary>
		public Shape BigTriangle2
		{
			get { return bigTriangle2; }
			set { bigTriangle2 = value; }
		}

		/// <summary>
		/// Texture2D that holds the medium triangle image
		/// </summary>
		public Shape MediumTriangle
		{
			get { return mediumTriangle; }
			set { mediumTriangle = value; }
		}

		/// <summary>
		/// Texture2D that holds the first small triangle image
		/// </summary>
		public Shape SmallTriangle1
		{
			get { return smallTriangle1; }
			set { smallTriangle1 = value; }
		}

		/// <summary>
		/// Texture2D that holds the second small triangle image
		/// </summary>
		public Shape SmallTriangle2
		{
			get { return smallTriangle2; }
			set { smallTriangle2 = value; }
		}

		/// <summary>
		/// Texture2D that holds the square image
		/// </summary>
		public Shape Square
		{
			get { return square; }
			set { square = value; }
		}

		/// <summary>
		/// Texture2D that holds the parallelogram image
		/// </summary>
		public Shape Parallelogram
		{
			get { return parallelogram; }
			set { parallelogram = value; }
		}

		/// <summary>
		/// Texture2D that holds the button image
		/// </summary>
		public Texture2D Button
		{
			get { return button; }
			set { button = value; }
		}

		/// <summary>
		/// SpriteFont that writes on the screen
		/// </summary>
		public SpriteFont Font
		{
			get { return font; }
			set { font = value; }
		}

		/// <summary>
		/// Initializes an object that handles drawing the game's screens
		/// </summary>
		public Gui()
		{
		}

		/// <summary>
		/// Draws the Menu screen
		/// </summary>
		public void DrawMenu()
        {
			//Sets Background Color
			gd.GraphicsDevice.Clear(Color.SandyBrown);

			//Displays Game Title
			sb.DrawString(font, "TANGRAM TROUBLE", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("TANGRAM TROUBLE").Length() / 2, 50), Color.DarkSlateGray);

			//Displays Buttons Instructing User How To Move Between Screens
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 100, 360, 30), Color.White);
			sb.DrawString(font, "Press Enter To Start The Game", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press Enter To Start The Game").Length() / 2, 104), Color.SteelBlue);
			
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 150, 360, 30), Color.White);
			sb.DrawString(font, "Press O To Go To The Options Menu", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press O To Go To The Options Menu").Length() / 2, 154), Color.SteelBlue);
		}

		/// <summary>
		/// Draws the Options screen
		/// </summary>
		public void DrawOptions()
        {
			//Sets Background Color
			gd.GraphicsDevice.Clear(Color.MintCream);

			//Displays Options Screen Title
			sb.DrawString(font, "OPTIONS:", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("OPTIONS:").Length() / 2, 50), Color.DarkSlateGray);

			//Displays Button Instructing User How To Move Between Screens
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 100, 360, 30), Color.White);
			sb.DrawString(font, "Press O To Return To The Previous Screen", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press O To Return To The Previous Screen").Length() / 2, 104), Color.SteelBlue);
		}

		/// <summary>
		/// Draws the GamePlay screen
		/// </summary>
		public void DrawGamePlay()
        {
			//Sets Background Color
			gd.GraphicsDevice.Clear(Color.Tan);

			//Placeholder Until Board Is Designed
			sb.DrawString(font, "Level 1", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Level 1").Length() / 2, 25), Color.DarkSlateGray);

			//Displays Button Instructing User How To Move Between Screens
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 50, 360, 30), Color.White);
			sb.DrawString(font, "Press Space To Pause The Game", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press Space To Pause The Game").Length() / 2, 54), Color.SteelBlue);

			//Outline Used To Represent The Shaped To Be Made Using The Tangram Pieces
			sb.Draw(outline, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 225, 100, 450, 600), Color.White);

			//Repository To Hold Blocks To Use In The Puzzles
			sb.Draw(button, new Rectangle(0, gd.GraphicsDevice.Viewport.Height - 175, gd.GraphicsDevice.Viewport.Width, 175), Color.DarkGray);

			//Displays All Of The Tangram Pieces
			bigTriangle1.Position = new Rectangle(50, gd.GraphicsDevice.Viewport.Height - 75, 100, 100);
			bigTriangle1.Draw(sb, Color.White);

			bigTriangle2.Position = new Rectangle(150, gd.GraphicsDevice.Viewport.Height - 75, 100, 100);
			bigTriangle2.Draw(sb, Color.White);

			mediumTriangle.Position = new Rectangle(250, gd.GraphicsDevice.Viewport.Height - 75, 100, 100);
			mediumTriangle.Draw(sb, Color.White);

			smallTriangle1.Position = new Rectangle(350, gd.GraphicsDevice.Viewport.Height - 75, 100, 100);
			smallTriangle1.Draw(sb, Color.White);

			smallTriangle2.Position = new Rectangle(450, gd.GraphicsDevice.Viewport.Height - 75, 100, 100);
			smallTriangle2.Draw(sb, Color.White);

			square.Position = new Rectangle(550, gd.GraphicsDevice.Viewport.Height - 75, 100, 100);
			square.Draw(sb, Color.White);

			parallelogram.Position = new Rectangle(650, gd.GraphicsDevice.Viewport.Height - 75, 100, 100);
			parallelogram.Draw(sb, Color.White);
		}

		/// <summary>
		/// Draws the Pause screen
		/// </summary>
		public void DrawPause()
        {
			//Sets Background Color
			gd.GraphicsDevice.Clear(Color.BlanchedAlmond);

			//Displays Paused Screen Title
			sb.DrawString(font, "PAUSED", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("PAUSED").Length() / 2, 50), Color.DarkSlateGray);

			//Displays Buttons Instructing User How To Move Between Screens
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 100, 360, 30), Color.White);
			sb.DrawString(font, "Press Space To Unpause The Game", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press Space To Unpause The Game").Length() / 2, 104), Color.SteelBlue);
			
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 150, 360, 30), Color.White);
			sb.DrawString(font, "Press O To Go To The Options Menu", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press O To Go To The Options Menu").Length() / 2, 154), Color.SteelBlue);
			
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 200, 360, 30), Color.White);
			sb.DrawString(font, "Press E Return To The Main Menu", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press E Return To The Main Menu").Length() / 2, 204), Color.SteelBlue);
		}

	}
}
