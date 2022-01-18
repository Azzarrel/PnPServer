using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PnPManager.Server.Data.Model;
using PnPManager.Server.Data.Services;

namespace PnPManager.Server.Implementation.Controllers
{



  [Authorize]
  [Route("api/[controller]")]
  public class MaterialController : Controller
  {
    public enum ResourceKey
    {
      GetMaterial
    }

    private IMaterialRepository MaterialProvider { get; set; }

    private IProductRepository ProductProvider { get; set; }



    public MaterialController(IMaterialRepository materialProvider, IProductRepository productProvider)
    {
      MaterialProvider = materialProvider;
      ProductProvider = productProvider;

    }

    [HttpGet("Material/{id}")]
    [Produces(typeof(Material))] //Required for API-Documentation; this way required data structures are also documented.
    public IActionResult GetMaterialById(int id)
    {



      var material = MaterialProvider.Get(id);
      return Ok(material);

    }

    [HttpGet("Product/{idProd}")]
    [Produces(typeof(Product))] //Required for API-Documentation; this way required data structures are also documented.
    public IActionResult GetProductById(int idProd)
    {

      return Ok(ProductProvider.Get(idProd));
    }

    [HttpPut("Material")]
    [Produces(typeof(Material))]
    public IActionResult PutMaterial([FromBody] Material entry)
    {
      MaterialProvider.Add(entry);
      return Ok(entry);

    }


    [HttpPut("Product")]
    [Produces(typeof(Product))]
    public IActionResult PutProduct([FromBody] Product entry)
    {
      ProductProvider.Add(entry);
      return Ok(entry);
    }


    [HttpPost("Ingredient")]
    [Produces(typeof(Product))]
    public IActionResult PostIngredient(int prodId, int matId)
    {
      bool result = ProductProvider.AddIngredient(prodId, matId);
      return Ok(result);
    }

  }
}
