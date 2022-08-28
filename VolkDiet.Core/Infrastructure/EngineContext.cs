using System.Runtime.CompilerServices;

namespace VolkDiet.Core.Infrastructure
{
    
    public class EngineContext
    {
      
        /// <summary>
        /// Create a static instance of the  engine.
        /// </summary>
       
        public static IEngine Create()
        {
        
            return  Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new VDEngine());
        }

       
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }
        
     

        
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }

   
    }
}
