using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
{
    public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository) { }

    protected override void Verify(ApplicantEducationPoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            if (string.IsNullOrEmpty(poco.Major))
            {
                exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Id} cannot be null or empty"));
            }
            else if (poco.Major.Length < 3)
            {
                exceptions.Add(new ValidationException(107, $"Major for ApplicantEducation {poco.Id} cannot be less than 3 characteres"));
            }

            //  Extracting DateTime for StartDate and CompletionDate
            
            DateTime startDate = poco.StartDate ?? DateTime.MinValue;
            DateTime completionDate = poco.CompletionDate ?? DateTime.MinValue;

            if (startDate> DateTime.Now)
            {
                exceptions.Add(new ValidationException(108, $"StartDate for ApplicantEducation {poco.Id} cannot be greater than today {DateTime.Now.Date}"));
            }

            if (completionDate < startDate)
            {
                exceptions.Add(new ValidationException(109, $"CompletionDate for ApplicantEducation {poco.Id} cannot be earlier than StartDate"));
            }

        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public override void Add(ApplicantEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(ApplicantEducationPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }


}
