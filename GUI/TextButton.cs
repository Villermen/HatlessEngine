﻿using System;

namespace HatlessEngine.GUI
{
	/// <summary>
	/// Base class for button controls that have text displayed in them (all of them, but Button was taken =S).
	/// </summary>
	public abstract class TextButton : GameObject
	{
		public ButtonState State;
		public Rectangle Bounds;

		public string Text;
		public Font TextFont;
		public Alignment TextAlignment;
		public Color TextColor;

		public int Depth;

		private Point TextPos;

		/// <summary>
		/// Occurs when the user has pressed the left mouse button while on the button bounds.
		/// </summary>
		public event EventHandler Pressed;
		/// <summary>
		/// Occurs when the user has pressed and released the left mouse button without leaving the button bounds in between.
		/// </summary>
		public event EventHandler Clicked;

		public TextButton(Rectangle bounds, string text, Font textFont, Color textColor, Alignment textAlignment, int depth = 0)
		{
			Bounds = bounds;

			Text = text;
			TextFont = textFont;
			TextColor = textColor;
			TextAlignment = textAlignment;

			Depth = depth;
		}

		public override void Step()
		{
			if (Bounds.IntersectsWith(Input.MousePosition))
			{
				//mouseover
				if (State == ButtonState.None)
					State = ButtonState.Mouseover;

				//pressed
				if (State == ButtonState.Mouseover && Input.IsPressed(Button.MouseLeft))
				{
					State = ButtonState.Mousedown;
					if (Pressed != null)
						Pressed(this, EventArgs.Empty);
				}

				//clicked
				if (State == ButtonState.Mousedown && Input.IsReleased(Button.MouseLeft))
				{
					if (Clicked != null)
						Clicked(this, EventArgs.Empty);

					State = ButtonState.Mouseover;	
				}
			}
			else
				State = ButtonState.None;

			if (!String.IsNullOrEmpty(Text))
			{
				if (TextAlignment.HasFlag(Alignment.Right))
					TextPos.X = Bounds.Position2.X;
				else if (TextAlignment.HasFlag(Alignment.Center))
					TextPos.X = Bounds.Center.X;
				else
					TextPos.X = Bounds.Position.X;

				if (TextAlignment.HasFlag(Alignment.Bottom))
					TextPos.Y = Bounds.Position2.Y;
				else if (TextAlignment.HasFlag(Alignment.Middle))
					TextPos.Y = Bounds.Center.Y;
				else
					TextPos.Y = Bounds.Position.Y;
			}
		}

		public override void Draw()
		{
			if (!String.IsNullOrEmpty(Text))
				TextFont.Draw(Text, TextPos, TextColor, TextAlignment, Depth);
		}
	}

	public enum ButtonState
	{
		None = 0,
		Mouseover = 1,
		Mousedown = 2,
	}
}