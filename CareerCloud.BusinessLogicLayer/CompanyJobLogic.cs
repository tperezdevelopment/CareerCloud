using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
{
    public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository) { }

    protected override void Verify(CompanyJobPoco[] pocos)
    {
        // TODO this is added by me, for this Entity not appear in the Assignment 3
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            if (poco.ProfileCreated.Date > DateTime.Now.Date)
            {
                exceptions.Add(new ValidationException(5000, $"ProfileCreated for CompanyJobPoco {poco.Id} cannot be greater than today {DateTime.Now.Date}"));
            }
        }
        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public override void Add(CompanyJobPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyJobPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }

}
