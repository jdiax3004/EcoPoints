using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ecoPoints.Controllers
{
    public class usuarioController : ApiController
    {
        [System.Web.Http.HttpPost]
        public String Post()
        {
            //-------------------------------------------------------------------------------------
            //----SWITCH QUE CONTROLA LA OPCION A EJECUTAR DEPENDIENDO DE LO QUE ELIJAMOS----------
            //-------------------------------------------------------------------------------------
            var Request = HttpContext.Current.Request;
            switch (Request["op"])//op variable opcion
            {
                case "Insertar"://PROCESO INSERTAR
                    {
                        var respuesta = ecoPoints.Models.Usuario.Registrar(Int32.Parse(Request["carne"]), Request["pass"]);
                        return respuesta;
                        break;
                    }

                default://PROCESO POR DEFECTO
                    {
                        return "hola";
                        break;
                    }
            }
        }
    }
}