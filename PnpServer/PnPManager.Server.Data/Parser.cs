using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnPManager.Server.Data
{
  public static class Parser
  {


    public static T CreateCopy<T>(this T obj, bool deepCopy = false)
    {

      var copy = Activator.CreateInstance<T>();
      copy.Adapt(obj, deepCopy);

      return copy;
    }

    public static void Adapt<T>(this T obj, T source, bool deepCopy = false)
    {
      var config = new TypeAdapterConfig();
      config.Default.ShallowCopyForSameType(!deepCopy);
      config.Default.PreserveReference(!deepCopy);
      TypeAdapter.Adapt(source, obj, config);
    }
  }
}
