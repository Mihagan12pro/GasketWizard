using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GasketWizard.Domain
{
    public abstract class KompasModel<T> : KompasModel
    {
        T Id { get; set; }
    }

    public abstract class KompasModel : IValidatableObject
    {
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);

        public abstract object GetId();

        public bool HasErrors
        {
            get
            {
                errors.Clear();

                var results = new List<ValidationResult>();
                var context = new ValidationContext(this);

                errors.AddRange(Validate(context).Select(e => e.ErrorMessage));

                return errors.Count() > 0;
            }
        }

        public IReadOnlyList<string> Errors
            => errors.AsReadOnly();

        protected List<string> errors = new List<string>();
    }
}