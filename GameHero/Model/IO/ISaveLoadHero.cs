using GameHero.Model.Data;

namespace GameHero.Model.IO
{
    public interface ISaveLoadHero
    {
        void Write(Hero hero);
        Hero Read(string heroName);
    }
}
