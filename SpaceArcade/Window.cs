using System;
using OpenTK;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace SpaceArcade
{
    public class Window : GameWindow
    {
        
        ShaderProgram program1;
        private int vertexBufferHandle;
        private int vertexArrayHandle;
        private int elementBufferHandle;
        //float[] testTriangle = TestObject.testTriangle;
        //uint[] indicies = TestObject.indicies;
        float[] tieAdvanced = TieAdvanced.tieAdvanced;
        uint[] indicies = TieAdvanced.indicies;

        private float rotZ = 0.0f;
        private float rotX = 0.0f;
        private float rotY = 0.0f;
        private float tiePosX = 0.0f;
        private float tiePosZ = 0.0f;
        private float tieSpeed = 1.0f;

        private float time = 0.0f;

        float speed = 3f;

        Vector3 position = new Vector3(0.0f, 0.0f, 3.0f);
        Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

        public Window(int width = 1440, int height = 1080, int refreshRate = 60)
          : base(
            new GameWindowSettings()
            {
                UpdateFrequency = refreshRate,

            },
            new NativeWindowSettings()
            {
                Title = "RenderWindow",
                ClientSize = new Vector2i(width, height),
                WindowBorder = WindowBorder.Hidden,
                StartFocused = true,
                StartVisible = false,
                API = ContextAPI.OpenGL,
                Profile = ContextProfile.Core,
                APIVersion = new Version(3, 3),

            })
            {
            CenterWindow();
            }


        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);
            base.OnResize(e);
        }

        protected override void OnLoad()
        {
            

            GL.ClearColor(new Color4(0.0f, 0.0f, 0.0f, 1.0f));
            this.IsVisible = true;

            this.vertexBufferHandle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexBufferHandle);
            GL.BufferData(BufferTarget.ArrayBuffer, tieAdvanced.Length * sizeof(float), tieAdvanced, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            this.vertexArrayHandle = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayHandle);

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.vertexArrayHandle);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0); 
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.BindVertexArray(0);

            elementBufferHandle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferHandle);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indicies.Length * sizeof(uint), indicies, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);



            program1 = new ShaderProgram();
            program1.shaderProgramId = ShaderProgram.LoadShaderProgram("../../../default.vert", "../../../default.frag");
            base.OnLoad();
        }

        protected override void OnUnload()
        {

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(vertexBufferHandle);
            GL.DeleteBuffer(vertexArrayHandle);
            GL.DeleteBuffer(elementBufferHandle);
            

            base.OnUnload();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (!IsFocused) // check to see if the window is focused
            {
                return;
            }
             
            KeyboardState input = KeyboardState;

            if (input.IsKeyDown(Keys.W))
            {
                position += front * speed * (float)UpdateTime; //Forward 
            }

            if (input.IsKeyDown(Keys.S))
            {
                position -= front * speed * (float)UpdateTime; //Backwards
            }

            if (input.IsKeyDown(Keys.A))
            {
                position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed * (float)UpdateTime; //Left
            }

            if (input.IsKeyDown(Keys.D))
            {
                position += Vector3.Normalize(Vector3.Cross(front, up)) * speed * (float)UpdateTime; //Right
            }

            if (input.IsKeyDown(Keys.Space))
            {
                position += up * speed * (float)UpdateTime; //Up 
            }

            if (input.IsKeyDown(Keys.LeftShift))
            {
                position -= up * speed * (float)UpdateTime; //Down
            }

            time += (float)UpdateTime;

            //tiePosX = -1*MathF.Sin(tieSpeed * time);
            //tiePosZ = -4-4*MathF.Cos(tieSpeed * time);

            //Console.WriteLine(time);
            int fps = (int)(1 / UpdateTime) + 1;
            Console.WriteLine("Fps: " + fps);

            //rotX = time;
            rotY = -1.57f + time;
            //rotZ = time;


            //rotZ += 0.01f;
            //rotX += 0.01f;
            //rotY += 0.01f;

            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            

            program1.Use();

            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            

            GL.BindVertexArray(this.vertexArrayHandle);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferHandle);
            GL.DrawElements(PrimitiveType.Lines, indicies.Length, DrawElementsType.UnsignedInt, 0);
            //GL.DrawArrays(PrimitiveType.Lines, 0, 3);


            Matrix4 model = Matrix4.Identity;

            //Camera
            //Matrix4 view = Matrix4.Identity;
            Matrix4 view = Matrix4.LookAt(position, position + front, up);


            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60.0f), 4.0f/3.0f, 0.1f, 100.0f);
            

            Matrix4 translation = Matrix4.CreateTranslation(tiePosX, 0.0f, tiePosZ);
            model = Matrix4.CreateRotationZ(rotZ)*Matrix4.CreateRotationY(rotY)*Matrix4.CreateRotationX(rotX);
            model *= translation;

            int modelLocation = GL.GetUniformLocation(program1.shaderProgramId, "model");
            int viewLocation = GL.GetUniformLocation(program1.shaderProgramId, "view");
            int projectionlLocation = GL.GetUniformLocation(program1.shaderProgramId, "projection");

            GL.UniformMatrix4(modelLocation, true, ref model);
            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionlLocation, true, ref projection);



            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);


            this.Context.SwapBuffers();
            base.OnRenderFrame(args);
        }


    }
}
