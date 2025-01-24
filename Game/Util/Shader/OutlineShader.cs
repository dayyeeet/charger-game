using Game.Util.Resource;
using Raylib_cs;

namespace Game.Util.Shader;

public class OutlineShader
{
    private readonly Raylib_cs.Shader _shader;

    public OutlineShader()
    {
        _shader = EmbeddedShader.LoadShader("Game.shaders.outline.fs")!.Value;
        
        if (_shader.Id == 0)
        {
            throw new Exception("Failed to load outline shader");
        }
    }

    public Raylib_cs.Shader GetShader()
    {
        return _shader;
    }

    public void SetOutlineSize(float size)
    {
        var location = Raylib.GetShaderLocation(_shader, "outlineSize");
        Raylib.SetShaderValue(_shader, location, size, ShaderUniformDataType.Float);
    }

    public void SetOutLineColor(Color color)
    {
        float[] normalizedColor =
        {
            color.R / 255.0f,
            color.G / 255.0f,
            color.B / 255.0f,
            color.A / 255.0f
        };
        var location = Raylib.GetShaderLocation(_shader, "outlineColor");
        Raylib.SetShaderValue(_shader, location, normalizedColor, ShaderUniformDataType.Vec4);
    }

    public void SetTextureSize(float width, float height)
    {
        float[] textureSize = {width, height};
        var location = Raylib.GetShaderLocation(_shader, "textureSize");
        Raylib.SetShaderValue(_shader, location, textureSize, ShaderUniformDataType.Vec2);
    }
}