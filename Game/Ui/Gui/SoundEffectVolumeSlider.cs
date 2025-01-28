using Engine.Util;
using Game.Util.Sound;
using Raylib_cs;

namespace Game.Ui.Gui;

public class SoundEffectVolumeSlider : Slider
{
    public SoundEffectVolumeSlider(int width, int height) : base(width, height)
    {
        Text = "Effect Volume";
        SliderValue = Game.Settings.SFXVolume;
    }

    public override void Update(Rectangle bounds, GameWindow window)
    {
        base.Update(bounds, window);
        SoundLoading.Sound.SetEffectVolume(SliderValue);
    }
}