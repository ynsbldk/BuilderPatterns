using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternBurakSelimSen
{
    public class Insan
    {
        public string Ad { get; set; }

        public int Yas { get; set; }

        public bool Cinsiyet { get; set; }

        public string Memleket { get; set; }
    }


    public interface IInsanOzelik
    {
        Insan Olustur();
        IInsanOzelik SetAd(string Ad);
        IInsanOzelik SetYas(int Yas);
        IInsanOzelik SetCinsiyet(bool Cinsiyet);
        IInsanOzelik SetMemleket(string Memleket);


    }

    public class InsanFactory : IInsanOzelik
    {
        Insan _insan;

        public InsanFactory(Insan insan)
        {
            _insan = insan;
        }

        public Insan Olustur()
        {
            return this._insan;
        }

        public IInsanOzelik SetAd(string Ad)
        {
            _insan.Ad = Ad;
            return this;
        }

        public IInsanOzelik SetCinsiyet(bool Cinsiyet)
        {
            _insan.Cinsiyet = Cinsiyet;
            return this;
        }

        public IInsanOzelik SetMemleket(string Memleket)
        {
            _insan.Memleket = Memleket;
            return this;
        }

        public IInsanOzelik SetYas(int Yas)
        {
            _insan.Yas = Yas;
            return this;
        }
    }

    public static class InsanInit
    {
        public static InsanFactory Init()
        {
            return new InsanFactory(new Insan);
        }

    }
}
