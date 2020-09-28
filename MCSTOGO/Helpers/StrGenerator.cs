using System;
using System.Linq;
using System.Text;

namespace MCSTOGO.Helpers
{
   public interface IStrGenerator
   {
      string IdGenerator();
      string UserIdGenerator();
      string AutoTypeGenerator();
        
      /// <summary>
      /// Generate id from a given length
      /// </summary>
      /// <param name="length"></param>
      /// <returns>string</returns>
      string PolyIdGenerator(int length);
   }

   public class StrGenerator : IStrGenerator
   {
      public string IdGenerator()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char) e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char) e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();
            return id;
        }

        public string UserIdGenerator()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char) e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char) e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(16)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();
            return id;
        }

        public string AutoTypeGenerator()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char) e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char) e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(10)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();
            return id;        }

        public string PolyIdGenerator(int length)
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char) e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char) e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(length)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();
            return id;
        }
   }
}