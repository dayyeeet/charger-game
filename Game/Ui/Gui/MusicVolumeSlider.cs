using Engine.Util;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Ui.Gui;

public class MusicVolumeSlider : Slider
{
    public MusicVolumeSlider(int width, int height) : base(width, height)
    {
        Text = "Music Volume";
        SliderValue = Game.Settings.MusicVolume;
    }

    public override void Update(Rectangle bounds, GameWindow window)
    {
        base.Update(bounds, window);
        SoundLoading.Music.SetMusicVolume(SliderValue);
    }
}