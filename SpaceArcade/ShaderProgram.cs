using System;
using OpenTK.Graphics.OpenGL;

namespace SpaceArcade
{
    internal class ShaderProgram
    {
        public int shaderProgramId;

        private static int LoadShader(string ShaderLocation, ShaderType type)
        {
            int shaderID = GL.CreateShader(type);
            GL.ShaderSource(shaderID, File.ReadAllText(ShaderLocation));
            GL.CompileShader(shaderID);
            string infoLog = GL.GetShaderInfoLog(shaderID);
            if (!string.IsNullOrEmpty(infoLog))
            {
                throw new Exception(infoLog);
            }

            return shaderID;
        }

        public static int LoadShaderProgram(string VertexShaderLocation, string FragmentShaderLocation) 
        {
            int shaderProgramId  = GL.CreateProgram();
            int vertexShaderId   = LoadShader(VertexShaderLocation, ShaderType.VertexShader);
            int fragmentShaderId = LoadShader(FragmentShaderLocation, ShaderType.FragmentShader);

            GL.AttachShader(shaderProgramId, vertexShaderId);
            GL.AttachShader(shaderProgramId, fragmentShaderId);
            GL.LinkProgram(shaderProgramId);

            GL.DeleteShader(vertexShaderId);
            GL.DeleteShader(fragmentShaderId);

            string infoLog = GL.GetProgramInfoLog(shaderProgramId);

            if (!string.IsNullOrEmpty(infoLog)) 
            {
                throw new Exception(infoLog);
            }

            return shaderProgramId;

        }

        public void Use()
        {
            GL.UseProgram(shaderProgramId);
        }



    }
}
