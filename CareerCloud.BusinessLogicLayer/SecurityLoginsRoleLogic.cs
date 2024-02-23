using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class SecurityLoginsRoleLogic : BaseLogic<SecurityLoginsRolePoco>
{
    public SecurityLoginsRoleLogic(IDataRepository<SecurityLoginsRolePoco> repository) : base(repository) { }

    protected override void Verify(SecurityLoginsRolePoco[] pocos)
    {
        List<ValidationException> exceptions = new List<ValidationException>();

        foreach (var poco in pocos)
        {
            // Adding some rules by tperezdevelopment
            if (poco.Login == Guid.Empty)
            {
                exceptions.Add(new ValidationException(5003, $"Login for SecurityLoginsRolePoco {poco.Id} cannot be null or empty"));
            }
            if (poco.Role == Guid.Empty)
            {
                exceptions.Add(new ValidationException(5004, $"Role for SecurityLoginsRolePoco {poco.Id} cannot be null or empty"));
            }
        }


        if (exceptions.Count > 0)
        {
            throw new AggregateException(exceptions);
        }
    }

    public override void Add(SecurityLoginsRolePoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }

    public override void Update(SecurityLoginsRolePoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }


}
