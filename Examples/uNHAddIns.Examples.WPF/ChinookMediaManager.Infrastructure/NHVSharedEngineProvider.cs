using System;
using NHibernate.Validator.Engine;

namespace ChinookMediaManager.Infrastructure
{
    public class NHVSharedEngineProvider : ISharedEngineProvider
    {
        private readonly ValidatorEngine _validatorEngine;

        public NHVSharedEngineProvider(ValidatorEngine validatorEngine)
        {
            _validatorEngine = validatorEngine;
        }

        /// <summary>
        /// Provide the shared engine instance.
        /// </summary>
        /// <returns>
        /// The validator engine.
        /// </returns>
        public ValidatorEngine GetEngine()
        {
            return _validatorEngine;
        }
    }
}