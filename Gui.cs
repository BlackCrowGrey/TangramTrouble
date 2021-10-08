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
			sb.DrawString(font, "Press Enter To Start The Game", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press Enter To Start The Game").Length() / 2, 104), Color.MediumPurple);
			
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 150, 360, 30), Color.White);
			sb.DrawString(font, "Press O To Go To The Options Menu", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press O To Go To The Options Menu").Length() / 2, 154), Color.MediumPurple);
		}

		/// <summary>
		/// Draws the Options screen
		/// </summary>
		public void DrawOptions()
        {
			//Sets Background Color
			gd.GraphicsDevice.Clear(Color.White);

			//Displays Options Screen Title
			sb.DrawString(font, "OPTIONS:", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("OPTIONS:").Length() / 2, 50), Color.DarkSlateGray);

			//Displays Button Instructing User How To Move Between Screens
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 100, 360, 30), Color.White);
			sb.DrawString(font, "Press O To Return To The Previous Screen", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press O To Return To The Previous Screen").Length() / 2, 104), Color.MediumPurple);
		}

		/// <summary>
		/// Draws the GamePlay screen
		/// </summary>
		public void DrawGamePlay()
        {
			//Sets Background Color
			gd.GraphicsDevice.Clear(Color.Tan);

			//Placeholder Until Board Is Designed
			sb.DrawString(font, "BOARD GOES HERE", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("BOARD GOES HERE").Length() / 2, 50), Color.DarkSlateGray);

			//Displays Button Instructing User How To Move Between Screens
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 100, 360, 30), Color.White);
			sb.DrawString(font, "Press Space To Pause The Game", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press Space To Pause The Game").Length() / 2, 104), Color.MediumPurple);

			//Repository To Hold Blocks To Use In The Puzzles
			sb.Draw(button, new Rectangle(0, gd.GraphicsDevice.Viewport.Height - 100, gd.GraphicsDevice.Viewport.Width, 100), Color.DarkGray);
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
			sb.DrawString(font, "Press Space To Unpause The Game", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press Space To Unpause The Game").Length() / 2, 104), Color.MediumPurple);
			
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 150, 360, 30), Color.White);
			sb.DrawString(font, "Press O To Go To The Options Menu", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press O To Go To The Options Menu").Length() / 2, 154), Color.MediumPurple);
			
			sb.Draw(button, new Rectangle(gd.GraphicsDevice.Viewport.Width / 2 - 180, 200, 360, 30), Color.White);
			sb.DrawString(font, "Press E Return To The Main Menu", new Vector2(gd.GraphicsDevice.Viewport.Width / 2 - font.MeasureString("Press E Return To The Main Menu").Length() / 2, 204), Color.MediumPurple);
		}
	}
}
