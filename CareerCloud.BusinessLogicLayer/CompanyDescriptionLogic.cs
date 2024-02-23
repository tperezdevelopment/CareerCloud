using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository) { }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyDescription) || poco.CompanyDescription.Length <= 2 )
                {
                    exceptions.Add(new ValidationException(107, $"CompanyDescription for CompanyDescriptionPoco {poco.Id} " +
                   $"must be greater than 2 characteres"));
                }

                if (string.IsNullOrEmpty(poco.CompanyName) || poco.CompanyName.Length <= 2)
                {
                    exceptions.Add(new ValidationException(106, $"CompanyName for CompanyDescriptionPoco {poco.Id} " +
                   $"must be greater than 2 characteres"));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }

        }

        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }

}
