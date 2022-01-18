using PnPManager.Server.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PnPManager.Server.Data.Services
{
  public class MaterialRepository : IMaterialRepository
  {

    private MaterialContext m_Context { get; }


    public MaterialRepository(MaterialContext context)
    {
      m_Context = context;
    }

    public bool Add(Material material)
    {
      m_Context.Materials.Add(material);
      m_Context.SaveChanges();
      return true;
    }

    public void Remove(Material material)
    {
      m_Context.Materials.Remove(material);
      m_Context.SaveChanges();
    }

    public bool Remove(int id)
    {
      var mat = Get(id);
      if(mat != null)
      {

        m_Context.Materials.Remove(mat);
        m_Context.SaveChanges();
        return true;
      }
      return false;
    }

    public Material Get(int id)
    {
      return m_Context.Materials.FirstOrDefault(m => m.Id == id);
    }

  }
}
