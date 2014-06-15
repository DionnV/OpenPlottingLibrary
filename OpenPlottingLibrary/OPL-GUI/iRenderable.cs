using OpenTK.Graphics;

namespace OPL_GUI
{
    public interface IRenderable
    {
        void Draw(Camera camera);

        /// <summary>
        /// Returns the shader programs that should be used to render this object.
        /// </summary>
        /// <returns></returns>
        int GetShaderProgramHandle();

        /// <summary>
        /// Returns the buffer object (VAO) where all the data resides that should rendered.
        /// </summary>
        /// <returns></returns>
        int GetBufferHandle();
    }
}