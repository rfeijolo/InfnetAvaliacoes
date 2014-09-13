using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Avaliacoes.Web.Infrastructure
{
    public static class LikertNameConverter
    {
        public static string Convert(int value)
        {
            switch (value)
            {
                case 0:
                    return "Insatisfatório";
                case 1:
                    return "Pouco satisfatório";
                case 2:
                    return "Satisfatório";
                case 3:
                    return "Muito satisfatório";
                case 4:
                    return "Extremamente satisfatório";

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}