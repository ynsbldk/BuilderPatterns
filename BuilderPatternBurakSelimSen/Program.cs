using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternBurakSelimSen
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero moonsta = FluentHeroFactory.Init()
                .GiveAColor("Blue")
                .GiveANickName("Monstar")
                .SetForceTo(50)
                .TakeHero();

            Insan insan = InsanInit.Init()
                .SetAd("Mehmet")
                .SetCinsiyet(true)
                .SetMemleket("Konya")
                .SetYas(29)
                .Olustur();
        }
    }

    class Hero
    {
        public string NickName { get; set; }
        public string Color { get; set; }
        public byte[] Gravatar { get; set; }
        public int InitialForce { get; set; }

    }

    interface IHeroFactory
    {
        Hero TakeHero();
        IHeroFactory SetForceTo(int ForceValue);
        IHeroFactory GiveANickName(string NickName);
        IHeroFactory GiveAGravatar(byte[] GravatarPath);
        IHeroFactory GiveAColor(string Color);

    }

    class HeroFactory : IHeroFactory
    {
        private Hero _hero;
        public HeroFactory(Hero hero)
        {
            _hero = hero;
        }
        public IHeroFactory GiveAColor(string Color)
        {
            _hero.Color = Color;
            return this;
        }

        public IHeroFactory GiveAGravatar(byte[] GravatarPath)
        {
            _hero.Gravatar = GravatarPath;
            return this;
        }

        public IHeroFactory GiveANickName(string NickName)
        {
            _hero.NickName = NickName;
            return this;
        }

        public IHeroFactory SetForceTo(int ForceValue)
        {
            _hero.InitialForce = ForceValue;
            return this;
        }

        public Hero TakeHero()
        {
            return this._hero;
        }
    }

    static class FluentHeroFactory
    {
        public static IHeroFactory Init()
        {
            return new HeroFactory(new Hero());
        }
    }
}
