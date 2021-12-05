using System.Collections.Generic;
using GameHero.Model.Data;

namespace GameHero.Model.IO
{
    public interface ISaveLoadLogin
    {
        void Write(IList<Login> logins);
        IList<Login> Read();
    }
}
