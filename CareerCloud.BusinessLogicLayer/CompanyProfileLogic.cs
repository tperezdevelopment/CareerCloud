using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer;

public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
{
    public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository) { }

    protected override void Verify(CompanyProfilePoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            if (!string.IsNullOrEmpty(poco.CompanyWebsite))
            {
                if (!Regex.IsMatch(poco.CompanyWebsite, @"^(https?://)?([a-zA-Z0-9-]+\.){1,2}(ca|com|biz)$"))
                {
                    exceptions.Add(new ValidationException(600, $"CompanyWebsite for CompanyProfilePoco {poco.Id} must end with the \r\nfollowing extensions – \".ca\", \".com\", \".biz."));
                }
            }

            if (string.IsNullOrEmpty(poco.ContactPhone) || !Regex.IsMatch(poco.ContactPhone, @"^\+(?:\d\s?){1,4}-?(\d\s?){1,15}$"))
            {
                exceptions.Add(new ValidationException(601, $"ContactPhone for CompanyProfilePoco {poco.Id} must correspond to a valid phone number (e.g. 416-555-1234)\r\n"));
            }

        }

        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public override void Add(CompanyProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(CompanyProfilePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }


}
