using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace DungeonShambles
{
	class Game: GameWindow
	{
		public static void Main (string[] args)
		{
			using (Game game = new Game())
			{
				init ();
				game.Run(30);
			}
		}

		private static void init() {
			GL.ClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			GL.MatrixMode (MatrixMode.Projection);
			GL.LoadIdentity ();
			GL.Ortho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Title = "Dungeon Shambles";
			GL.ClearColor(Color.FromArgb (204, 159, 213));
		}

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GL.Color3(Color.FromArgb(239, 80, 145));

			GL.Begin(PrimitiveType.Quads);
			GL.Vertex2 (0.25, 0.75);
			GL.Vertex2 (0.75, 0.75);
			GL.Vertex2 (0.75, 0.25);
			GL.Vertex2 (0.25, 0.25);
			GL.End ();

			SwapBuffers();
		}

		protected override void OnResize(EventArgs e) {}
	}
}