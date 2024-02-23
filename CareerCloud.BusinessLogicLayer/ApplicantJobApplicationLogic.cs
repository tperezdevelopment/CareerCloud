using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
{
    public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository) { }

    protected override void Verify(ApplicantJobApplicationPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            if (poco.ApplicationDate.Date > DateTime.Now.Date)
            {
                exceptions.Add(new ValidationException(110, $"ApplicationDate for ApplicantJobApplicationPoco {poco.Id} " +
                                 $"cannot be greater than today {DateTime.Now.Date} "));
            }
        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public override void Add(ApplicantJobApplicationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantJobApplicationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
}
