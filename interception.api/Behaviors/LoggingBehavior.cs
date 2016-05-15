namespace interception.api.Behaviors
{
    using System;
    using System.Collections.Generic;

    using log4net;

    using Microsoft.Practices.Unity.InterceptionExtension;

    public class LoggingBehavior : IInterceptionBehavior
    {
        // Obtener una instancia del logger mediante la frábrica estática
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoggingBehavior));

        // Este método permite implementar alguna lógica que determine, en tiempo de ejecución, si 
        // este comportamiento debe ejecutarse o no. En este caso se ejecuta siempre y por tanto 
        // este método siempre devuelve 'true'.
        public bool WillExecute => true;

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Log.Debug(string.Format("Incoming call in {0} method", input.MethodBase));

            // El delegado 'getNext' que este método recoge como parámetro contiene la llamada
            // interceptada. Al ejecutarlo esta tiene lugar.
            var result = getNext()(input, getNext);

            if (result.Exception != null)
            {
                Log.Error(string.Format("Error in method {0}: {1}->{2}", input.MethodBase, result.Exception.GetType().Name, result.Exception.Message));
            }
            else
            {
                Log.Debug(string.Format("{0} method executed", input.MethodBase));
            }

            return result;
        }
    }
}