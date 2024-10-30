namespace Engine;

//Anything in our game that is a visual Element will somehow inherit this interface
public interface IGameUpdatable
{
    //Called before every render
    void Update() {}
    
    //Renders something
    void Draw();
}