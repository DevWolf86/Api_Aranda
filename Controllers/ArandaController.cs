using AccesoDatos;
using Api_Aranda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;

namespace Api_Aranda.Controllers
{
    public class ArandaController : ApiController
    {
        private ArandaDbEntities Context = new ArandaDbEntities();

        [HttpGet]
        [Route("api/aranda/getall")]
        public IEnumerable<productos> GetAll()
        {
            List<productos> products = new List<productos>();
            using (ArandaDbEntities db = new ArandaDbEntities())
            {
                var resultado = db.producto.ToList();
                foreach (var item in resultado)
                {
                    productos p = new productos()
                    {
                        idcategoria = item.idcategoria,
                        idproducto = item.idproducto,
                        idimagen = item.idimagen,
                        nombreproducto = item.nombreproducto
                    };
                    products.Add(p);
                }
                products = products.OrderBy(o => o.nombreproducto).ToList();
                return products;
            }
        }

        [HttpGet]
        [Route("api/aranda/get/{id}")]
        public productos Get(int id)
        {
            try
            {
                using (ArandaDbEntities db = new ArandaDbEntities())
                {
                    var y =  db.producto.FirstOrDefault(x => x.idproducto.Equals(id));
                    productos p = new productos()
                    {
                        idcategoria = y.idcategoria,
                        idproducto = y.idproducto,
                        idimagen = y.idimagen,
                        nombreproducto = y.nombreproducto
                    };
                    return p;
                }
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IHttpActionResult AgregarProducto([FromBody] productos Producto)
        {
            if (ModelState.IsValid)
            {
                producto p = new producto()
                {
                    idcategoria = Producto.idcategoria,
                    idproducto = Producto.idproducto,
                    idimagen = Producto.idimagen,
                    nombreproducto = Producto.nombreproducto
                };
                Context.producto.Add(p);
                Context.SaveChanges();
                return Ok(Producto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult EliminarProducto (int id)
        {
            var producto = Context.producto.Find(id);
            if (producto != null)
            {
                Context.producto.Remove(producto);
                Context.SaveChanges();

                return Ok(producto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IHttpActionResult EditarProducto([FromBody] productos Producto)
        {
            if (ModelState.IsValid)
            {
                producto p = new producto()
                {
                    idcategoria = Producto.idcategoria,
                    idproducto = Producto.idproducto,
                    idimagen = Producto.idimagen,
                    nombreproducto = Producto.nombreproducto
                };
                Context.producto.Attach(p);
                Context.SaveChanges();
                return Ok(Producto);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
