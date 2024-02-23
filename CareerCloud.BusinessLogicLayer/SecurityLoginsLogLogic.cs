using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityLoginsLogLogic : BaseLogic<SecurityLoginsLogPoco>
{
    public SecurityLoginsLogLogic(IDataRepository<SecurityLoginsLogPoco> repository) : base(repository) { }

    protected override void Verify(SecurityLoginsLogPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            // Adding some rules by tperezdevelopment
            if (poco.Login == Guid.Empty)
            {
                exceptions.Add(new ValidationException(5001, $"Login for SecurityLoginsLogPoco {poco.Id} cannot be null or empty"));
            }
            if (string.IsNullOrEmpty(poco.SourceIP))
            {
                exceptions.Add(new ValidationException(5002, $"SourceIP for SecurityLoginsLogPoco {poco.Id} cannot be null or empty"));
            }
        }


        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public override void Add(SecurityLoginsLogPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(SecurityLoginsLogPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }


}
