using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class OfertasComercialesBusiness
    {
        public decimal RegistrarImagen(IMGOfertasComeciales Imagen)
        {
            Imagen.FechaCreacion = DateTime.Now;
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.IMGOfertasComeciales.Add(Imagen);
            unitWork.Complete();
            unitWork.Dispose();
            return Imagen.IdImagen;
        }
        public IMGOfertasComeciales ConsultarImagenPorId(decimal IdImagen)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IMGOfertasComeciales imagen = new IMGOfertasComeciales();
            imagen = unitWork.IMGOfertasComeciales.Find(x => x.IdImagen == IdImagen).FirstOrDefault();
            return imagen;
        }
        public void ActualizarImagen(IMGOfertasComeciales Imagen)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IMGOfertasComeciales ImagenParaActualizar = new IMGOfertasComeciales();
            ImagenParaActualizar = unitWork.IMGOfertasComeciales.Find(x => x.IdImagen == Imagen.IdImagen).FirstOrDefault();
            if (ImagenParaActualizar != null) 
            {
                ImagenParaActualizar.Link = Imagen.Link;
                ImagenParaActualizar.Descripcion = Imagen.Descripcion;
                ImagenParaActualizar.UsuarioCreacion = Imagen.UsuarioCreacion;
                ImagenParaActualizar.FechaCreacion = DateTime.Now;
                ImagenParaActualizar.Imagen = Imagen.Imagen;
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        public List<IMGOfertasComeciales> ListaDeImagenesAdmin()
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<IMGOfertasComeciales> Lista = new List<IMGOfertasComeciales>();
            Lista = unitWork.IMGOfertasComeciales.GetAll().ToList();
            return Lista;
        }
    }
}
