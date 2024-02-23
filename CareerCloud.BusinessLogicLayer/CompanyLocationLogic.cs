using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyLocationLogic : BaseLogic<CompanyLocationPoco>
{
    public CompanyLocationLogic(IDataRepository<CompanyLocationPoco> repository) : base(repository) { }

    protected override void Verify(CompanyLocationPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            if (string.IsNullOrEmpty(poco.CountryCode))
            {
                exceptions.Add(new ValidationException(500, $"CountryCode for CompanyLocationPoco {poco.Id} cannot be null or empty"));
            }
            if (string.IsNullOrEmpty(poco.Province))
            {
                exceptions.Add(new ValidationException(501, $"Province for CompanyLocationPoco {poco.Id} cannot be null or empty"));
            }
            if (string.IsNullOrEmpty(poco.Street))
            {
                exceptions.Add(new ValidationException(502, $"Street for CompanyLocationPoco {poco.Id} cannot be null or empty"));
            }
            if (string.IsNullOrEmpty(poco.City))
            {
                exceptions.Add(new ValidationException(503, $"City for CompanyLocationPoco {poco.Id} cannot be null or empty"));
            }

            if (string.IsNullOrEmpty(poco.PostalCode))
            {
                exceptions.Add(new ValidationException(504, $"PostalCode for CompanyLocationPoco {poco.Id} cannot be null or empty"));
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public override void Add(CompanyLocationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyLocationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

}