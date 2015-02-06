using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Assimp;
using System.Collections.Generic;

namespace DungeonShambles
{
	public class ModelImporter
	{
		Scene model;

		public ModelImporter ()
		{
		}

		public void importModel(String name)
		{
			String fileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), name);

			AssimpContext importer = new AssimpContext();

			model = importer.ImportFile(fileName, PostProcessPreset.TargetRealTimeMaximumQuality);
		}

		private static int r = 1;

		public void renderModel() {
			foreach(Mesh mesh in model.Meshes) {
				List<Vector3D> meshVector = mesh.Vertices;
				GL.Begin (OpenTK.Graphics.OpenGL.PrimitiveType.TriangleFan);
				GL.Color3(Color.FromArgb(239, 80, 145));
				for (int i = 0; i < meshVector.Count; i++) {
					GL.Vertex3 (meshVector [i].X, meshVector [i].Y, meshVector [i].Z);
				}
				GL.End ();
				GL.Rotate (r, 1.0f, 1.0f, 1.0f);
				r += 1;
			}
		}

	}
}

