//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.EntityFrameworkCore;
//using PnPManager.Server.Data.Model;

//namespace PnPManager.Server.Data.Services
//{
//  public class ProductRepository : IProductRepository
//  {

//    private MaterialContext m_Context { get; }


//    public ProductRepository(MaterialContext context)
//    {
//      m_Context = context;
//    }

//    public bool Add(Product product)
//    {
//      m_Context.Products.Add(product);
//      m_Context.SaveChanges();
//      return true;
//    }

//    public bool AddIngredient(int prodId, int matId)
//    {
//      var product = m_Context.Products.Where(p => p.Id == prodId).Include(p => p.Ingredients).FirstOrDefault();
//      var material = m_Context.Materials.FirstOrDefault(m => m.Id == matId);



//      if(product == null || material == null)
//        return false;

//      if(product.Ingredients == null)
//        product.Ingredients = new List<Material>();



//      product.Ingredients.Add(material);
//      m_Context.SaveChanges();
//      return true;
//    }



//    public void Remove(Product product)
//    {
//      m_Context.Products.Remove(product);
//      m_Context.SaveChanges();
//    }

//    public bool Remove(int id)
//    {
//      var mat = Get(id);
//      if(mat != null)
//      {

//        m_Context.Products.Remove(mat);
//        m_Context.SaveChanges();
//        return true;
//      }
//      return false;
//    }

//    public Product Get(int id)
//    {
//      return m_Context.Products.Where(m => m.Id == id).Include(p => p.Ingredients).FirstOrDefault();
//    }

//  }
//}
