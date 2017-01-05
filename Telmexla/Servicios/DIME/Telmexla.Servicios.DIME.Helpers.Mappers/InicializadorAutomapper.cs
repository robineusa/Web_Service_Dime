using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telmexla.Servicios.DIME.Helpers.Mappers
{
    public class InicializadorAutomapper
    {
        public static void Execute()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.AddProfile<GeneralMapper>();
            });
        }

    }
}
